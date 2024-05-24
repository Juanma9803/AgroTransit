using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasuraInventario : MonoBehaviour
{
    private int cantidadBasura = 0; // Cantidad de basura en el inventario

    public int CantidadBasura
    {
        get { return cantidadBasura; }
    }

    public void AgregarBasura(int cantidad)
    {
        cantidadBasura += cantidad;
        Debug.Log("Se agregaron " + cantidad + " unidades de basura al inventario.");
        Debug.Log("Cantidad total de basura en el inventario: " + cantidadBasura);
    }

    public void QuitarBasura(int cantidad)
    {
        cantidadBasura = Mathf.Max(0, cantidadBasura - cantidad); // Asegurar que la cantidad no sea negativa
        Debug.Log("Se quitaron " + cantidad + " unidades de basura del inventario.");
        Debug.Log("Cantidad total de basura en el inventario: " + cantidadBasura);
    }
}

