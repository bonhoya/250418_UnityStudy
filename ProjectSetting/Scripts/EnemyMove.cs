using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] Transform monsterTransform;

    [SerializeField] Transform target;
    
    private float enemySpeed = 3f;
    public void Trace()
    {
        Debug.Log("�÷��̾ �ѽ��ϴ�");
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, enemySpeed * Time.deltaTime);
        transform.LookAt(target.transform.position);
    }
}
