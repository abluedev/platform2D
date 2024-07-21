using System;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    public bool _isOnFloor;
    
    public float jumpForce = 15f;
    public bool canDobleJump;
    public Transform feetPosition;
    public float checkRadius;
    public LayerMask groundLayer;
    
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

    }

    void Update()
    { 
        Jump();
    }
    
    void Jump()
    {
        _isOnFloor = Physics2D.OverlapCircle(feetPosition.position, checkRadius, groundLayer);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_isOnFloor)
            {
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
                canDobleJump = true;
            }
        }
        DoubleJump();
    }

    private void DoubleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_isOnFloor && canDobleJump)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
            canDobleJump = false;
        }
    }
}