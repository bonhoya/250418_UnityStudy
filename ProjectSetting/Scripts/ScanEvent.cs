using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class ScanEvent : MonoBehaviour
{
    public UnityEvent myEvent;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
            myEvent.Invoke();
    }

}
