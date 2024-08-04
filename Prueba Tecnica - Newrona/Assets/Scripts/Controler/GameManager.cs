using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject throwButton;

    [SerializeField]
    private GameObject numberRing;    
    
    [SerializeField]
    private GameObject startInfo;   
    
    [SerializeField]
    private GameObject throwNumber;

    [SerializeField]
    private GameObject points;
    
    [SerializeField]
    private GameObject endInfo;

    [SerializeField]
    private LoadSceneManager loadSceneManager;

    [SerializeField]
    private AudioSource emisor;

    [SerializeField]
    private AudioClip winGame;

    private readonly float volumen = 0.5f;

    private Timekeeper timekeeper;

    private ARPlaneManagerD arPlaneManagerD;

    private bool _sartGame = false;


    // Start is called before the first frame update
    void Start()
    {
        timekeeper = transform.GetComponent<Timekeeper>();
        arPlaneManagerD = transform.GetComponent<ARPlaneManagerD>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_sartGame)
        {
            startInfo.SetActive(true);
            StartCoroutine(Wait());
        }
        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3.0f); // Espera 2 segundos
        timekeeper.IniciarCronometro();
        throwButton.SetActive(true);
        numberRing.SetActive(false);
        startInfo.SetActive(false);
        throwNumber.SetActive(true);
        points.SetActive(true);
        arPlaneManagerD.OfARPlane();
        _sartGame = false;
    }

    public void StarGame()
    {
        _sartGame = true;
    }

    public void StopGame()
    {
        _sartGame = false;
    }

    public void EndGame()
    {
        endInfo.SetActive(true);
        StartCoroutine(Wait2());
    }


    IEnumerator Wait2()
    {
        yield return new WaitForSeconds(3.0f);
        loadSceneManager.LoadNextScene();
        emisor.PlayOneShot(winGame, volumen);
    }
}
