using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ThrowBalls : MonoBehaviour
{
    [SerializeField]
    private GameObject ballPrefab;

    [SerializeField]
    private Button button;

    [SerializeField]
    private float ballSpeed;

    [SerializeField]
    private GameObject ballSpanwPoint;

    [SerializeField]
    private TMP_Text throwNumber;

    [SerializeField]
    private GameObject throwNumberObject;

    [SerializeField]
    private Material[] materiales; // Una matriz de materiales para elegir al azar

    private MeshRenderer rnderer;

    private int indice = 0;

    private GameObject ball;

    private Camera arCamara;

    private int numberBall;

    private readonly float life = 8f;


    void Start()
    {
        button.GetComponent<Image>().color = materiales[indice].color;
    }

    void Update()
    {
        numberBall = ballSpanwPoint.transform.childCount;
        if (throwNumberObject.activeSelf)
        {
            throwNumber.text = "Lanzadas: " + numberBall;
        }
    }


    public void Lanzamietno()
    {
        arCamara = Camera.main;
        

        if (numberBall <= 2 )
        {
            ball = Instantiate(ballPrefab, arCamara.transform.position, arCamara.transform.rotation);
            ball.GetComponent<Rigidbody>().velocity = arCamara.transform.forward * ballSpeed;
            ball.transform.SetParent(ballSpanwPoint.transform);

            BallColor(ball);

            Destroy(ball, life);
        }
    }

    public void BallColor(GameObject b)
    {
        int numbreChild = b.transform.childCount;
       
        for (int i = 0; i < numbreChild; i++)
        {
            rnderer = b.transform.GetChild(i).GetComponent<MeshRenderer>();
            rnderer.material = materiales[indice];
        }

        RandomColor();
    }

    public void RandomColor()
    {
        indice = Random.Range(0, materiales.Length);
        button.GetComponent<Image>().color = materiales[indice].color;
    }

}
