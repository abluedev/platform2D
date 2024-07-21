using System;
using System.Numerics;
using UniRx;
using UnityEngine;
public class DashController: MonoBehaviour {
        private Rigidbody2D _rigidbody2D;
        public float velocity;
        PlayerController _playerController;
        private UnityEngine.Vector3 _dashDirection;
        private float localDirection = 1;
        public bool isDashing = false;
        void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _playerController = FindObjectOfType<PlayerController>();
            
        }
    
        void Update()
        {
            Dash();
            if (isDashing)
            {
                Observable.Timer(TimeSpan.FromSeconds(0.3f)).Subscribe(_ => isDashing = false);
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