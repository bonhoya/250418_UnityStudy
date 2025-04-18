using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet0418 : MonoBehaviour
{
    [SerializeField] Rigidbody bulletRigid;
    [SerializeField] GameObject impactEffect;

    private void Update()
    {
        if(bulletRigid.velocity.magnitude > 0)
        {
            transform.forward = bulletRigid.velocity;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        Instantiate(impactEffect, transform.position, transform.rotation);

    }
}
