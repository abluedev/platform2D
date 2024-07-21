using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private DashController _dashController;
    public float direction;
    public float windForce = 5f;

    private readonly float SPEED = 5f;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _dashController = GetComponent<DashController>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D.drag = windForce; 


    }

    // Update is called once per frame
    void Update()
    {
        Walk(); }


    private void Walk()
    {
        /*
         *     var direction = (int)Input.GetAxisRaw("Horizontal");
               _rigidbody2D.velocity = new Vector2(direction * SPEED, _rigidbody2D.velocity.y);
               _animator.SetBool("isRunning", direction == 1 || direction == -1);
               _spriteRenderer.flipX = direction == -1;
         */

        if (!_dashController.isDashing)
        {
            direction = (int)(Input.GetAxisRaw("Horizontal"));
            if (direction == 1 || direction == -1)
            {
                _rigidbody2D.velocity = new Vector2(direction * SPEED, _rigidbody2D.velocity.y);
                _animator.SetBool("isRunning", direction == 1 || direction == -1);
                _spriteRenderer.flipX = direction == -1;

            }
        }
    }
}
