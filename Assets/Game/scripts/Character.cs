using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterController _cc; 

    public float move_speed = 5f; 

    private Vector3 _movement_velocity; 

    private PlayerInput _player_input; 

    private void Awake()
    {
        _cc = GetComponent<CharacterController>(); 
        _player_input = GetComponent<PlayerInput>(); 
    }

    private void CalculatePlayerMovement()
    {
        _movement_velocity.Set(_player_input.HorizontalInput, 0f, _player_input.VerticalInput);
        _movement_velocity.Normalize(); 
        _movement_velocity = Quaternion.Euler(0, -45f,0) * _movement_velocity;
        _movement_velocity *= move_speed * Time.deltaTime; 
    }

    private void FixedUpdate()
    {
        CalculatePlayerMovement();
        _cc.Move(_movement_velocity);
    }
}
