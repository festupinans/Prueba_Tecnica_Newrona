using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ballTrigger : MonoBehaviour
{
    private ScoreAsigner scoreAsigner;
    
    private readonly float life = 0.5f;

    void Start()
    {
        scoreAsigner = transform.parent.GetComponent<ScoreAsigner>();
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("Ring"))
        {
            //Debug.Log("Vio anillo");
            Material cMaterial = c.gameObject.GetComponent<MeshRenderer>().material;
            Material bMaterial = transform.GetChild(1).GetComponent<MeshRenderer>().material;

            scoreAsigner.Point(bMaterial, cMaterial);
        
            Destroy(gameObject, life);
        }

        
    }
}
