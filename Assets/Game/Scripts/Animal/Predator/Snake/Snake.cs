using System.Collections;
using UnityEngine;

public class Snake : Predator
{
    [SerializeField] private float _changeDirectionInterval = 2f;
    
    protected override void Start()
    {
        base.Start();
        StartCoroutine(SnakeChangeDirectionRoutine());
    }

    protected override void Move()
    {
        if (_isDead) return;
        
        transform.position += _moveDirection * _moveSpeed * Time.fixedDeltaTime;
        
        if (_moveDirection != Vector3.zero)
        {
            transform.forward = _moveDirection;
        }
    }

    private IEnumerator SnakeChangeDirectionRoutine()
    {
        while (!_isDead)
        {
            yield return new WaitForSeconds(_changeDirectionInterval);
            ChooseRandomDirection();
        }
    }
}