using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StunGun : MonoBehaviour
{
    private Vector3 cPos;
    public GameObject stunBullet;
    public bool isShooting;
    public float timeForShoot = .2f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cPos = transform.localPosition;
        PlayerShoot();
    }

    void PlayerShoot()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            StartCoroutine(Firing());
        }
    }

    IEnumerator Firing()
    {
        if (isShooting == false)
        {
            isShooting = true;
            if (isShooting == true)
            {
                yield return new WaitForSeconds(timeForShoot);
                Shooting();
                isShooting = false;
            }
        }
    }

    void Shooting()
    {
        GameObject bulletInstantiate = Instantiate(stunBullet, cPos, transform.rotation);
        if (stunBullet != null)
        {
            stunBullet.transform.position = transform.position;
            stunBullet.transform.rotation = transform.rotation;
            stunBullet.SetActive(true);
        }
    }
    
}
