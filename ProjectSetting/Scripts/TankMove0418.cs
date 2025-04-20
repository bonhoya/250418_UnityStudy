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
    private Coroutine coroutine;
    private WaitForSeconds waitForSeconds = new WaitForSeconds(1f);

    private void Update()
    {
        Mover();
        RotateTurret();
        #region ContinuousFireFunc
        /*if (Input.GetKey(KeyCode.Space) && coroutine == null)
        {
            coroutine = StartCoroutine(CountinuousFire());
        }
        else if (Input.GetKeyUp(KeyCode.Space) && coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }*/

        #endregion

        #region ChargingFireFunc
        if(Input.GetKey(KeyCode.Space) && coroutine == null)
        {
            coroutine = StartCoroutine(ChargingFire());
        }
        #endregion
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

    public IEnumerator CountinuousFire()
    {
        while (true)
        {
            tankShooter0418.Fire();
            yield return waitForSeconds;
        }
    }

    public IEnumerator ChargingFire()
    {
        float timer = 0;
        while (true)
        {
            timer += Time.deltaTime * 10;
            yield return null;
            if (Input.GetKeyUp(KeyCode.Space))
            {
                break;
            }
        }

        float speed = Mathf.Clamp(timer, 1f, 50f);
        tankShooter0418.Fire(speed);
        coroutine = null;
        yield break;
    }

}
