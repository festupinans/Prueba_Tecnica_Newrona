using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;


public class Ring : MonoBehaviour
{
    [SerializeField]
    private GameObject arcoPrefab;

    [SerializeField]
    private GameObject ringSpawnPoint;

    [SerializeField]
    private Material[] materiales; // Una matriz de materiales para elegir al azar

    [SerializeField]
    private TMP_Text numberRing;

    private int numberOfRing;

    private MeshRenderer rnderer;

    private GameManager gameManager;

    private GameObject ring;

    private ARRaycastManager arRaycastManager;

    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private bool start = true;

    void Start()
    {
        arRaycastManager = FindObjectOfType<ARRaycastManager>();
        gameManager = transform.GetComponent<GameManager>();
    }

    void Update()
    {
        numberOfRing = ringSpawnPoint.transform.childCount; 

        if (start && ringSpawnPoint.transform.childCount == 5)
        {
            gameManager.StarGame();
            start = false;
        }

        if (start)
        {
            numberRing.text = ringSpawnPoint.transform.childCount + " Aros";
        }

        if (Input.touchCount > 0) 
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                var touchPosition = touch.position;

                bool esOverUI = touchPosition.isOverUI();

                if (esOverUI)
                {

                }

                if(!esOverUI && arRaycastManager.Raycast(touchPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
                {
                    Pose hitPose = hits[0].pose;

                    if(numberOfRing <= 4)
                    {
                        ringInstantiate(hitPose);

                        ringRandomColor();
                    }
                }
            }
        }
    }

    public void ringInstantiate(Pose hitpose)
    {
        ring = Instantiate(arcoPrefab, hitpose.position, hitpose.rotation);

        ring.transform.SetParent(ringSpawnPoint.transform);

        
    }

    public void ringRandomColor()
    {
        rnderer = ring.transform.GetChild(1).GetComponent<MeshRenderer>();
        
        rnderer.material = materiales[Random.Range(0, materiales.Length)];
        
    }
}
