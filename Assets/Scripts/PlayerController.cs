using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private readonly float SPEED = 5f;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var direction = (int) Input.GetAxisRaw("Horizontal");
        if (direction == 1)
        {
            _rigidbody2D.velocity = new Vector2(SPEED, _rigidbody2D.velocity.y);
        }
        else if (direction == -1)
        {
            _rigidbody2D.velocity = new Vector2(- SPEED, _rigidbody2D.velocity.y);
        }
        else
        {
            _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);
        }
    }
}
