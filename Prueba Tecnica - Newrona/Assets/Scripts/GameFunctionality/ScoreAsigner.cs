using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;


public class ScoreAsigner : MonoBehaviour
{
    [SerializeField]
    private Score score;

    [SerializeField]
    private Timekeeper timekeeper;

    private int tenPoints=10;
    private int onePoints=1;





    public void Point(Material bMaterial, Material cMaterial)
    {
        if (timekeeper.GetSegundos() >= 15 && timekeeper.GetMinutos() == 0)
        {
            tenPoints = 8;
        }
        else if (timekeeper.GetSegundos() >= 30 && timekeeper.GetMinutos() == 0)
        {
            tenPoints = 7;
        }
        else if (timekeeper.GetSegundos() >= 45 && timekeeper.GetMinutos() == 0)
        {
            tenPoints = 6;
        }
        else if (timekeeper.GetSegundos() >= 60 && timekeeper.GetMinutos() == 0)
        {
            tenPoints = 5;
        }
        else
        {
            tenPoints = 5;
        }

        if (cMaterial.name == bMaterial.name)
        {
            //Debug.Log("Son iguales");
            score.SetScore(tenPoints);
        }
        else if(cMaterial.name != bMaterial.name)
        {
            //Debug.Log("No son iguales");
            score.SetScore(onePoints);
        }
    }
}
