using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ControladorJuego : MonoBehaviour
{
    [SerializeField] private float tiempoMaximo;
    [SerializeField] private Slider slider;
    [SerializeField] private GameReset gameReset;
    private float tiempoActual;
    private bool tiempoActivado = false;

    /*private void Start()
    {
        ActivarTemporizador();
    }*/

    private void Update()
    {
        if (tiempoActivado)
        {
            CambiarContador();
        }
    }

    private void CambiarContador()
    {
        tiempoActual -= Time.deltaTime;

        if (tiempoActual >= 0)
        {
            slider.value = tiempoActual;
        }

        if (tiempoActual <= 0)
        {
            Debug.Log("El tiempo se ha acabado");
            CambiarTemporizador(false);
            gameReset.ResetGame();

        }
    }

    private void CambiarTemporizador(bool estado)
    {
        tiempoActivado = estado;
    }

    public void ActivarTemporizador()
    {
        tiempoActual = tiempoMaximo;
        slider.maxValue = tiempoMaximo;
        CambiarTemporizador(true);
    }


    public void DesactivarTemporizador()
    {
        CambiarTemporizador(false);
    }
}