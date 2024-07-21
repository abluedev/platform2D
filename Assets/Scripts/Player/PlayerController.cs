using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerControllerAnimations _playerControllerAnimations;
    private PlayerMovementController _playerMovementController;

    private float direction;
    private bool isOnFloor;

    void Start()
    {
        _playerControllerAnimations = GetComponent<PlayerControllerAnimations>();
        _playerMovementController = GetComponent<PlayerMovementController>();
    
    }

    void Update()
    {
        Walk();
        Jump();
    }

    public void Walk()
    {
        direction = _playerMovementController.Walk();
        _playerControllerAnimations.StartOrStopAnimateRun(direction);
        _playerControllerAnimations.TurnOutSprite(direction);

    }
    
    public void Jump()
    {
        isOnFloor = _playerMovementController.Jump();
        _playerControllerAnimations.StartOrStopAnimateRun(direction);
        _playerControllerAnimations.TurnOutSprite(direction);

    }
}
