using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunBullet : MonoBehaviour
{
    public Rigidbody rb;

    public float sTimer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        rb.AddRelativeForce(new Vector3(5,0,0),ForceMode.Impulse);
    }

    private void OnDisable()
    {
        sTimer = 4f;
        rb.velocity = Vector3.zero;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        sTimer = sTimer - Time.deltaTime;
        if (sTimer <= 0f)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("hit enemy");
            gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Wall"))
        {
            Debug.Log("hit wall");
            gameObject.SetActive(false);
        }
    }
}
