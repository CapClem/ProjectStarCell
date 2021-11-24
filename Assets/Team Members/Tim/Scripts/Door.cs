using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool locked;
    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (locked == false)
        {
            if (other.CompareTag("Player"))
            {
                StartCoroutine(Open());
            }
        }

        if (locked == true)
        {
            GetComponent<Collider>().isTrigger = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (locked == false)
        {
            GetComponent<Collider>().isTrigger = true;
        }
    }

    IEnumerator Open()
    {
        transform.position = startPos + new Vector3(0, 2, 0);
        yield return new WaitForSeconds(.5f);
        transform.position = startPos;
    }
}
