using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private ProjectStarCell controls;

    private Vector2 move;

    public float speed = 10;
    
    void Awake()
    {
        controls = new ProjectStarCell();
        controls.Player.Move.performed += ctx => move = ctx.ReadValue<Vector2>(); //on button press gets the movement value and starts the movement
        controls.Player.Move.canceled += ctx => move = Vector2.zero; //on button release stops movement
    }
    
    private void OnEnable()
    {
        controls.Player.Enable(); //enables movement on start
    }

    private void OnDisable()
    {
        controls.Player.Disable(); //disables movement on end
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(move.x, 0.0f, move.y)*speed*Time.deltaTime; //gets a value based on actual seconds not pc specs that is used to calculate movement
        transform.Translate(movement, Space.World); // gets the movement value and makes it relative to the world coordinates
    }
}