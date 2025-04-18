using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class TankMove0418 : MonoBehaviour
{
    [Header("탱크 움직임 제한")]
    [Range(1, 50)]
    [SerializeField] float tankSpeed;
    [Range(10, 100)]
    [SerializeField] float tankRotateSpeed;

    [Header("터렛 움직임 제한")]
    [SerializeField] GameObject turretPrefab;
    private float turretRotateSpeed = 50;

    private void Update()
    {
        Mover();
        RotateTurret();
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
        if(Input.GetKeyDown(KeyCode.D))
        {
            turretPrefab.transform.Rotate(Vector3.up, turretRotateSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            turretPrefab.transform.Rotate(Vector3.up, -turretRotateSpeed * Time.deltaTime);
        }
    }

}
