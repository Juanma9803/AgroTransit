using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetObjects : MonoBehaviour
{
    BasuraInventario inventario;

    [SerializeField] KeyCode interactKey = KeyCode.E; // Tecla para interactuar

    void Start()
    {
        inventario = GetComponent<BasuraInventario>();
        if (inventario == null)
        {
            Debug.LogError("El inventario de basura no está conectado.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Basura"))
        {
            Debug.Log("Presiona '" + interactKey.ToString() + "' para recoger la basura.");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Basura") && Input.GetKeyDown(interactKey))
        {
            inventario.AgregarBasura(1); // Añadir una unidad de basura al inventario
            Destroy(other.gameObject);
            Debug.Log("Bolsa de basura recogida. Total en inventario: " + inventario.CantidadBasura);
        }
    }
}

