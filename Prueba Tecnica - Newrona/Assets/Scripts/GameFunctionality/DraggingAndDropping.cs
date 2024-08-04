using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class DraggingAndDropping : MonoBehaviour
{
    //Objeto a instanciar
    [SerializeField]
    private GameObject objectPrefab;

    //Almacena el objeto instanciado
    private GameObject objectPlaced;
    
    //Almacena la funcionalidad de Raycast
    private ARRaycastManager raycastManager;

    //Almacena el GameObject de la camara
    private Camera arCamara;

    //Almacena los hits
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    //Almacena la posicion del topuch
    private Vector2 touchPosition = default;

    //almacena el bool que determina si el dedo continua tocando la pantalla
    private bool onTouchHold = false;

    
    void Start()
    {
        arCamara = Camera.main;
        raycastManager = FindObjectOfType<ARRaycastManager>();
    }

    void Update()
    {
        //Condicion que captura el evento de tocar la pantalla
        if (Input.touchCount > 0)
        {
            //Almacena el primer toque de la pantalla en una variable
            Touch touch = Input.GetTouch(0);

            touchPosition = touch.position;

            //Condicion para ver si el dedo toco la pantalla
            if(touch.phase == TouchPhase.Began)
            {
                Ray ray = arCamara.ScreenPointToRay(touch.position);
                RaycastHit hitObject;

                if(Physics.Raycast(ray, out hitObject))
                {
                    if (hitObject.transform.name.Contains("Sphere")){
                        onTouchHold = true;
                    }
                }                
            }

            //Condicion para ver si dejo de tocar la pantalla
            if (touch.phase == TouchPhase.Ended)
            {
                onTouchHold = false;
            }
        };

           
        //Se manda el raycast buscando tocar un Trackable Object
        if (raycastManager.Raycast(touchPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;

            //Si no existe un objeto instanciado, instancia uno
            //Si si existe un objeto intanciado, lo mueve
            if(objectPlaced == null)
            {
                objectPlaced = Instantiate(objectPrefab, hitPose.position, hitPose.rotation);
            }
            else
            {
                //Condicion que se activa cuando se esta tocando la pantalla
                if (onTouchHold)
                {
                    objectPlaced.transform.position = hitPose.position;
                    objectPlaced.transform.rotation = hitPose.rotation;
                }
            }
        }
        

    }
}
