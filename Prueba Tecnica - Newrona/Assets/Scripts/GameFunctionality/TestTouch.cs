using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TestTouch : MonoBehaviour
{
    private ARRaycastManager raycastManager;
    public GameObject objectToPlace;

    private List<ARRaycastHit> hits= new List<ARRaycastHit>();

    void Start()
    {

        raycastManager = FindObjectOfType<ARRaycastManager>();
    }


    void Update()
    {

        if(Input.touchCount > 0)
        {
            Vector2 touch = Input.GetTouch(0).position;

             if(raycastManager.Raycast(touch, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
            {
                var hitpose = hits[0].pose;
                Instantiate(objectToPlace, hitpose.position, hitpose.rotation);
            }
            
        };
    }
}
