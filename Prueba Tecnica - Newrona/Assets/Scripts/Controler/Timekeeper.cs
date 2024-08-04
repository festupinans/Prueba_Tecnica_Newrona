using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timekeeper : MonoBehaviour
{
    [SerializeField]
    private TMP_Text timeText;

    private float tiempoPasado = 0f;

    private bool cronometroActivo = false;

    private int _minutos;
    private int _segundos;


    public int GetMinutos()
    {
        return _minutos;
    }

    public int GetSegundos()
    {
        return _segundos;
    }

    void Update()
    {
        if (cronometroActivo)
        {
            tiempoPasado += Time.deltaTime;
            ActualizarTiempo();
        }
    }

    private void ActualizarTiempo()
    {
        _minutos = Mathf.FloorToInt(tiempoPasado / 60);
        _segundos = Mathf.FloorToInt(tiempoPasado % 60);

        timeText.text = string.Format("Tiempo: {0:00}:{1:00}", _minutos, _segundos);
        ContolPoints.Instante.SaveTime(string.Format("{0:00}:{1:00}", _minutos, _segundos));
    }

    public void IniciarCronometro()
    {
        cronometroActivo = true;
    }

    public void DetenerCronometro()
    {
        cronometroActivo = false;
    }

    public void ReiniciarCronometro()
    {
        tiempoPasado = 0f;
        ActualizarTiempo();
    }
}
