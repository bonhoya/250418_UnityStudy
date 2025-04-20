using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TankShooter0418 : MonoBehaviour
{
    [Header("Bullet And MuzzlePoint")]
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform muzzlePoint;

    [Header("BulletSpeed")]
    [Range(1, 30)][SerializeField] float bulletSpeed;

    public void Fire()
    {
            GameObject instance = Instantiate(bulletPrefab, muzzlePoint.position, muzzlePoint.rotation);
            Rigidbody bulletrigid = instance.GetComponent<Rigidbody>();
            bulletrigid.velocity = muzzlePoint.forward * bulletSpeed;
    }
    public void Fire(float bulletSpeed)
    {
        GameObject instance = Instantiate(bulletPrefab, muzzlePoint.position, muzzlePoint.rotation);
        Rigidbody bulletrigid = instance.GetComponent<Rigidbody>();
        bulletrigid.velocity = muzzlePoint.forward * bulletSpeed;
    }

    
}
