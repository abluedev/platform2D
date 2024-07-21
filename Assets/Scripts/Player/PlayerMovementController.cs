using System;
using UniRx;
using UnityEngine;

public class PlayerMovementController: MonoBehaviour
    {
        private PlayerControllerAnimations _playerControllerAnimations;
        
        private Rigidbody2D _rigidbody2D;
        public float velocity;
      
        private UnityEngine.Vector3 _dashDirection;
        private float localDirection = 1;
        public float jumpForce = 15f;
        public float checkRadius;
        private bool isDashing;
        private SpriteRenderer _spriteRenderer;
        public Transform feetPosition;
        public LayerMask groundLayer;
        private readonly float SPEED = 5f;
        
        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _playerControllerAnimations = GetComponent<PlayerControllerAnimations>();
        }
        
        public bool Jump()
        {
            var isOnFloor = Physics2D.OverlapCircle(feetPosition.position, checkRadius, groundLayer);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isOnFloor)
                {
                    _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
                }
            }
            return isOnFloor;
        }
        
        
        public float Walk()
        {
            var direction = (int)Input.GetAxisRaw("Horizontal");
            if (!isDashing)
            {
                _rigidbody2D.velocity = new Vector2(direction * SPEED, _rigidbody2D.velocity.y);
            }
            return direction;
        }

        public void Dash(float direction)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _dashDirection = GetDirection(direction);
                isDashing = true;
                _rigidbody2D.AddForce(_dashDirection * new Vector2(10,0), ForceMode2D.Impulse);
                Observable.Timer(TimeSpan.FromSeconds(0.5)).Subscribe( _=> isDashing = false );
            }
        }

     
        private UnityEngine.Vector3 GetDirection(float direction)
        {
            if (direction == 1 || direction == -1)
            {
                localDirection = direction;
            }

            if (localDirection == 1)
            {
                return transform.right;
            } 
            return -transform.right;
        }
    }
