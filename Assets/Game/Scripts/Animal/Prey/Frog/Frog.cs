using System.Collections;
using UnityEngine;

public class Frog : Prey
{
    [SerializeField] private float _jumpInterval = 2f;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private float _jumpDistance = 3f;
    
    private bool _isJumping = false;
    
    protected override void Start()
    {
        base.Start();
        StartCoroutine(JumpRoutine());
    }
    
    protected override void Move()
    {
        
    }
    
    private IEnumerator JumpRoutine()
    {
        while (!_isDead)
        {
            yield return new WaitForSeconds(_jumpInterval);
            
            if (!_isDead && !_isJumping)
            {
                Jump();
            }
        }
    }
    
    private void Jump()
    {
        _isJumping = true;
        
        Vector3 jumpDirection = _moveDirection.normalized;

        if (_moveDirection != Vector3.zero)
        {
            transform.forward = _moveDirection;
        }
        
        _rigidbody.AddForce(jumpDirection * _jumpDistance + Vector3.up * _jumpForce, ForceMode.Impulse);

        ChooseRandomDirection();
        
        StartCoroutine(ResetJumpFlag());
    }
    
    private IEnumerator ResetJumpFlag()
    {
        yield return new WaitForSeconds(0.5f);
        _isJumping = false;
    }
}
