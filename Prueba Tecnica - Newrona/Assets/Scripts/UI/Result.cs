using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Result : MonoBehaviour
{
    [SerializeField]
    private TMP_Text points;

    [SerializeField]
    private TMP_Text time;

    void Start()
    {     
        points.text = ContolPoints.Instante.GetPoints().ToString();
        time.text = ContolPoints.Instante.GetTime();
    }
}
