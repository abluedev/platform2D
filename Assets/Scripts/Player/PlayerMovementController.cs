using System;
using UniRx;
using UnityEngine;

public class PlayerMovementController: MonoBehaviour
    {

        private Rigidbody2D _rigidbody2D;
        public float velocity;
        PlayerController _playerController;
        private UnityEngine.Vector3 _dashDirection;
        private float localDirection = 1;
        public bool isDashing = false;
        public bool isOnFloor;
        public float jumpForce = 15f;
        public bool canDobleJump;
        public float checkRadius;
        
        public Transform feetPosition;
        public LayerMask groundLayer;
    
        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            Dash();
            if (isDashing)
            {
                Observable.Timer(TimeSpan.FromSeconds(0.3f)).Subscribe(_ => isDashing = false);
                
            }
        }

        void Update()
        { 
            Jump();
        }
        
        private void Jump()
        {
            isOnFloor = Physics2D.OverlapCircle(feetPosition.position, checkRadius, groundLayer);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isOnFloor)
                {
                    _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
                    canDobleJump = true;
                }
            }
            DoubleJump();
        }
        
        private void DoubleJump()
        {
            if (Input.GetKeyDown(KeyCode.Space) && !isOnFloor && canDobleJump)
            {
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
                canDobleJump = false;
            }
        }
        
        
        private void Dash()
        {
            _dashDirection = GetDirection();
            
            if (!isDashing && Input.GetKeyDown(KeyCode.Q))
            {
                
                isDashing = true;
                _rigidbody2D.AddForce(_dashDirection * velocity, ForceMode2D.Impulse);
                
            }
        }

    
        private UnityEngine.Vector3 GetDirection()
        {
            if (_playerController.direction == 1 || _playerController.direction == -1)
            {
                localDirection = _playerController.direction;
            }

            if (localDirection == 1)
            {
                return transform.right;
            } 
            return -transform.right;
        }
    }
