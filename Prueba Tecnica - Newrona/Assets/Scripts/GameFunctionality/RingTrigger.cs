using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RingTrigger : MonoBehaviour
{
    //[SerializeField]
    //private LayerMask layerTrigger;

    [SerializeField]
    private Canvas textAlertCanvas;

    private readonly float life = 3f;

    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.CompareTag("Ring Trigger"))
        {
            Canvas canvas;
            canvas = Instantiate(textAlertCanvas, transform.position, transform.rotation);
            canvas.transform.SetParent(transform.parent);
            Destroy(transform.parent.gameObject, life);
        }
    }
}
