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
        
        _rigidbody.linearVelocity = _moveDirection * _moveSpeed;
        
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