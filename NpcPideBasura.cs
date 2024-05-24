using UnityEngine;

public class NpcPideBasura : MonoBehaviour
{
    private BasuraInventario inventario;
    private bool enZona;

    void Start()
    {
        // Buscar el objeto con el tag "Player" en lugar de asignarlo directamente
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            // Obtener el componente BasuraInventario del objeto con el tag "Player"
            inventario = playerObject.GetComponent<BasuraInventario>();
            if (inventario == null)
            {
                Debug.LogError("El jugador no tiene un componente 'BasuraInventario'.");
            }
        }
        else
        {
            Debug.LogError("No se encontró el objeto con la etiqueta 'Player'.");
        }
    }

    void Update()
    {
        if (enZona && Input.GetKeyDown(KeyCode.E))
        {
            if (inventario != null)
            {
                if (inventario.CantidadBasura >= 5)
                {
                    inventario.QuitarBasura(5); // Quitar 5 bolsas de basura del inventario
                    Debug.Log("¡Misión completada!");
                }
                else
                {
                    Debug.Log("Aún faltan bolsas de basura");
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Verificar si el collider del objeto que entró es el del jugador
        if (other.CompareTag("Player"))
        {
            enZona = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Verificar si el collider del objeto que salió es el del jugador
        if (other.CompareTag("Player"))
        {
            enZona = false;
        }
    }
}
