using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float tiempoActual;

    public int segundos,minutos,horas;

    public TextMeshProUGUI Reloj;

    private void Update() 
    {
        tiempoActual += Time.deltaTime;

        minutos = Mathf.FloorToInt((tiempoActual % 3600)/ 60);
        horas = Mathf.FloorToInt(tiempoActual / 3600);
        segundos = Mathf.FloorToInt(tiempoActual % 60);

        Tiempo10Min();

    } 

    void Tiempo10Min()
    {
        Reloj.text = string.Format("{0:00},{1:00},{2:00}",horas,minutos,segundos);
    }
}
