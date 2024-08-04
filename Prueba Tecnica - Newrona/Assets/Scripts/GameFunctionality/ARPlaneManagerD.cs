using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARPlaneManagerD : MonoBehaviour
{
    [SerializeField]
    private ARPlaneManager arPlaneManager; // Arrastra el AR Plane Manager al Inspector

    // El nombre del prefab de plano que deseas ocultar
    [SerializeField]
    private string nombreDelPrefabAOcultar = "ARDefaultPlane";

    //void Awake()
    //{
        //arPlaneManager = GetComponent<ARPlaneManager>();    
    //}

    public void OfARPlane()
    {
        arPlaneManager.enabled = false;
        // Recorremos la lista de todos los planos detectados por el AR Plane Manager
        foreach (ARPlane arPlane in arPlaneManager.trackables)
        {
            if(arPlane != null)
            {
                arPlane.gameObject.GetComponent<ARPlaneMeshVisualizer>().enabled = false;
            }
        }
    }
}
