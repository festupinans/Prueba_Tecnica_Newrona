using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContolPoints : MonoBehaviour
{
    public static ContolPoints Instante;

    private int _points;
    private string _time;

    private void Awake()
    {
        if (ContolPoints.Instante == null)
        {
            ContolPoints.Instante = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SavePoints(int points)
    {
        _points = points;
    }

    public void SaveTime(string time)
    {
        _time = time;
    }

    public int GetPoints()
    {
        return _points;
    }

    public string GetTime()
    {
        return _time;
    }
}
