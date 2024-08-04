using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PointsAnimation : MonoBehaviour
{
    [SerializeField]
    private AudioSource emisor;

    [SerializeField]
    private AudioClip pointClick;

    [SerializeField]
    private AudioClip fakePointClick;

    [SerializeField]
    private float volumen;


    private Animator animatorController;

    void Start()
    {
        animatorController = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.CompareTag("Ball"))
        {
            Material cMaterial = trigger.transform.GetChild(1).GetComponent<MeshRenderer>().material;
            Material bMaterial = GetComponent<MeshRenderer>().material;

            

            if (cMaterial.name == bMaterial.name)
            {
                animatorController.Play("Aros");
                Debug.Log(cMaterial.name + " y " + bMaterial.name);

                emisor.PlayOneShot(pointClick, volumen);
            }
            else if(cMaterial.name != bMaterial.name)
            {
                animatorController.Play("ArosFake");
                emisor.PlayOneShot(fakePointClick, volumen);

            }
        }
    }
}
