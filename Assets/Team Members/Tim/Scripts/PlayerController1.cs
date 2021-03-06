using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController1 : MonoBehaviour
{
    private ProjectStarCell controls;

    private Vector2 move;
    private float jump;

    public float speed = 10;
    public float jumpforce;
    private Rigidbody rb;
    private RaycastHit hit;
    private RaycastHit Doublehit;
    public bool doubleJump = false;
    private GameObject parentObject;
    private GameObject childObject;
    private Vector3 jumpVelocity;
    void Awake()
    {
        controls = new ProjectStarCell();
        controls.Player.Move.performed += ctx => move = ctx.ReadValue<Vector2>(); //on button press gets the movement value and starts the movement
        controls.Player.Move.canceled += ctx => move = Vector2.zero; //on button release stops movement
        controls.Player.Jump.performed += ctx => jump = ctx.ReadValue<float>();
        //controls.Player.Jump.canceled += ctx => jump = 0;
        rb = GetComponent<Rigidbody>();
        parentObject = GameObject.Find("Cube");
        childObject = parentObject.transform.GetChild(0).gameObject;
    }
    

    private void OnEnable()
    {
        controls.Player.Enable(); //enables movement on start
    }

    private void OnDisable()
    {
        controls.Player.Disable(); //disables movement on end
    }

    private void Update()
    {
        
        Vector3 movement = new Vector3(move.x, 0.0f, move.y)*speed*Time.deltaTime; //gets a value based on actual seconds not pc specs that is used to calculate movement
        
        if (controls.Player.Jump.triggered)
        {
            if (doubleJump == false)
            {
                Jump();
            }
        }

        if (doubleJump == true)
        {
            if (controls.Player.Jump.triggered)
            {
                Doublejump();
            }
        }
        
        transform.Translate(movement, Space.World); // gets the movement value and makes it relative to the world coordinates
        if (Physics.Raycast(transform.position, -Vector3.up, out hit,.6f))
        {
            Debug.DrawLine(transform.position, hit.point, Color.cyan);
        }

        if (Physics.Raycast(childObject.transform.position, -Vector3.up, out Doublehit,.6f))
        {
            Debug.DrawLine(childObject.transform.position, Doublehit.point, Color.cyan);
        }
    }

    private void Jump()
    {
        jumpVelocity = new Vector2(0f, jumpforce);
        
        if (hit.collider != false)
        {
            rb.velocity += jumpVelocity;
        }
        if (hit.collider == false)
        {
            //jumpforce = 0f;
        }
        Vector2 vel = rb.velocity;
        vel.y += Physics.gravity.y;
    }

    private void Doublejump()
    {
        jumpVelocity = new Vector2(0f, jumpforce);
        if (hit.collider !=false)
        {
            rb.velocity += jumpVelocity;
        }

        if (Doublehit.collider != false)
        {
            rb.velocity += jumpVelocity;
        }
        Vector2 vel = rb.velocity;
        vel.y += Physics.gravity.y;
    }
}
