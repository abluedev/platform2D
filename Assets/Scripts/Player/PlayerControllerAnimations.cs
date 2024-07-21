using System;
using UnityEngine;

public class PlayerControllerAnimations : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void StartOrStopAnimateRun(float direction)
    {
        _animator.SetBool("isRunning", direction == 1 || direction == -1);
        if (direction == 0)
        {
            _animator.SetBool("isRunning", false);
            // _animator.SetBool("idle", true);

        }
    }

    public void TurnOutSprite(float direction)
    {
        _spriteRenderer.flipX = direction == -1;
    }

}
    
    