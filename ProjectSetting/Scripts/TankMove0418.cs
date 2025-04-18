using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class TankMove0418 : MonoBehaviour
{
    [Header("Setting Of TankSpeed")]
    [Range(1, 50)]
    [SerializeField] float tankSpeed;
    [Range(10, 100)]
    [SerializeField] float tankRotateSpeed;

    [Header("Setting Of TurretSpeed")]
    [SerializeField] GameObject turretPrefab;
    private float turretRotateSpeed = 80;

    [SerializeField] TankShooter0418 tankShooter0418;
    private void Update()
    {
        Mover();
        RotateTurret();
        tankShooter0418.Fire();
    }

    private void Mover()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * tankSpeed * Time.deltaTime, Space.World);
            Quaternion quaternionVector3 = Quaternion.LookRotation(Vector3.forward);
            transform.rotation = Quaternion.Lerp(transform.rotation, quaternionVector3, tankRotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back * tankSpeed * Time.deltaTime, Space.World);
            Quaternion quaternionVector3 = Quaternion.LookRotation(Vector3.back);
            transform.rotation = Quaternion.Lerp(transform.rotation, quaternionVector3, tankRotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * tankSpeed * Time.deltaTime, Space.World);
            Quaternion quaternionVector3 = Quaternion.LookRotation(Vector3.right);
            transform.rotation = Quaternion.Lerp(transform.rotation, quaternionVector3, tankRotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * tankSpeed * Time.deltaTime, Space.World);
            Quaternion quaternionVector3 = Quaternion.LookRotation(Vector3.left);
            transform.rotation = Quaternion.Lerp(transform.rotation, quaternionVector3, tankRotateSpeed * Time.deltaTime);
        }
    }

    private void RotateTurret()
    {
        if(Input.GetKey(KeyCode.D))
        {
            turretPrefab.transform.Rotate(Vector3.up, turretRotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            turretPrefab.transform.Rotate(Vector3.up, -turretRotateSpeed * Time.deltaTime);
        }
    }

}
