using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] Transform monsterTransform;

    private GameObject target;
    private float enemySpeed = 3f;
    private void Update()
    {
        Patrol();
        if(target != null)
        {
            Trace();
        }
    }

    private void Patrol()
    {
        if (Physics.Raycast(monsterTransform.position, monsterTransform.forward, out RaycastHit hitInfo, 10f))
        {
            Debug.DrawLine(monsterTransform.position, hitInfo.point, Color.red);
            if (hitInfo.collider.gameObject.tag == "Player")
            {
                target = hitInfo.collider.gameObject;
            }
            else
                target = null;

        }
        else
        {
            Debug.DrawLine(monsterTransform.position, monsterTransform.position + monsterTransform.forward * 10f, Color.blue);
            target = null;
        }
    }

    private void Trace()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, enemySpeed * Time.deltaTime);
        transform.LookAt(target.transform.position);
    }
}
