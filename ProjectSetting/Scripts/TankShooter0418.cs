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

    private WaitForSeconds waitForSeconds = new WaitForSeconds(1f);
    public bool isChargeOver = false;
    [SerializeField] TankMove0418 tankMove0418;
    private void Fire()
    {
            GameObject instance = Instantiate(bulletPrefab, muzzlePoint.position, muzzlePoint.rotation);
            Rigidbody bulletrigid = instance.GetComponent<Rigidbody>();
            bulletrigid.velocity = muzzlePoint.forward * bulletSpeed;
    }
    private void Fire(float bulletSpeed)
    {
        GameObject instance = Instantiate(bulletPrefab, muzzlePoint.position, muzzlePoint.rotation);
        Rigidbody bulletrigid = instance.GetComponent<Rigidbody>();
        bulletrigid.velocity = muzzlePoint.forward * bulletSpeed;
    }

    public IEnumerator CountinuousFire()
    {
        while (true)
        {
            Fire();
            yield return waitForSeconds;
        }
    }

    public IEnumerator ChargingFire()
    {
        float timer = 0;
        while(true)
        {
            timer += Time.deltaTime * 10;
            yield return null;
            if(Input.GetKeyUp(KeyCode.Space))
            {
                break;
            }
        }

        float speed = Mathf.Clamp(timer, 1f, 50f);

        Fire(speed);
        isChargeOver = true;
    }
}
