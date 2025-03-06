using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public abstract class Animal : MonoBehaviour
{
    [Inject] protected UIManager _uiManager;
    
    [SerializeField] protected float _moveSpeed = 3f;
    [SerializeField] protected Rigidbody _rigidbody;
    
    protected Vector3 _moveDirection;
    protected bool _isDead = false;
    protected float lifeTime = 0;
    
    public enum AnimalType
    {
        Prey,
        Predator
    }
    
    public AnimalType Type { get; protected set; }
    
    protected virtual void Start()
    {
        if (_rigidbody == null)
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        ChooseRandomDirection();
    }
    
    protected virtual void Update()
    {
        if (_isDead) return;
        lifeTime += Time.deltaTime;
    }

    protected virtual void FixedUpdate()
    {
        if (_isDead) return;

        CheckBoundaries();
        Move();
    }
    
    protected abstract void Move();
    
    protected virtual void ChooseRandomDirection()
    {
        _moveDirection = new Vector3(
            Random.Range(-1f, 1f),
            0,
            Random.Range(-1f, 1f)
        ).normalized;
    }
    
    protected virtual void CheckBoundaries()
    {
        Camera mainCamera = Camera.main;
        if (mainCamera == null) return;
        
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);
        
        if (viewportPosition.x < 0 || viewportPosition.x > 1 || viewportPosition.y < 0 || viewportPosition.y > 1)
        {
            Vector2 randomViewportPoint = new Vector2(Random.Range(0.1f, 0.9f), Random.Range(0.1f, 0.9f));
            
            Vector3 targetWorldPoint = mainCamera.ViewportToWorldPoint(
                new Vector3(randomViewportPoint.x, randomViewportPoint.y, viewportPosition.z));
            
            Vector3 directionToTarget = targetWorldPoint - transform.position;
            directionToTarget.y = 0;
            
            _moveDirection = directionToTarget.normalized;
        }
    }
    
    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (_isDead) return;
        
        Animal otherAnimal = collision.gameObject.GetComponent<Animal>();
        
        if (otherAnimal == null) return;
        
        HandleCollision(otherAnimal);
    }
    
    protected virtual void HandleCollision(Animal otherAnimal)
    {
        
    }

    public float GetLifeTime() => lifeTime;
    
    public virtual void Die()
    {
        if (_isDead) return;
        
        _isDead = true;
        
        if (Type == AnimalType.Prey)
        {
            _uiManager.IncreaseDeadPreyCount();
        }
        else
        {
            _uiManager.IncreaseDeadPredatorCount();
        }
        
        Destroy(gameObject);
    }
}