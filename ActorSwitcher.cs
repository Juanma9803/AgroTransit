using UnityEngine;

public class ActorSwitcher : MonoBehaviour
{
    public GameObject vehicle;
    public GameObject character;
    public GameObject vehicleCamera;
    public GameObject characterCamera;
    public Transform characterSpawnPoint; // Punto de aparición del jugador al salir del vehículo
    public float interactionDistance = 2f; // Distancia máxima para interactuar con el vehículo
    public float verticalOffset = 1f; // Desplazamiento vertical al salir del vehículo

    private bool isCharacterActive = true;
    private Rigidbody characterRigidbody; // Rigidbody del personaje

    void Start()
    {
        SwitchControl();
        characterRigidbody = character.GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Verificar si el jugador está junto al collider y pulsó la tecla "C"
        if (Input.GetKeyDown(KeyCode.C))
        {
            // Si el jugador está junto al collider y no está dentro del vehículo, entra en él
            if (IsPlayerNearCollider() && isCharacterActive)
            {
                EnterVehicle();
            }
            // Si el jugador está dentro del vehículo, sale de él
            else if (!isCharacterActive)
            {
                ExitVehicle();
            }
        }
    }

    bool IsPlayerNearCollider()
    {
        // Verificar si el jugador está dentro del rango de interacción con el vehículo
        float distanceToCollider = Vector3.Distance(transform.position, character.transform.position);
        return distanceToCollider <= interactionDistance;
    }

    void EnterVehicle()
    {
        isCharacterActive = false;
        SwitchControl();
    }

    void ExitVehicle()
    {
        isCharacterActive = true;
        SwitchControl();
        // Colocar al jugador junto al vehículo, en el lado izquierdo y con un desplazamiento vertical
        Vector3 offset = -vehicle.transform.right * 2f; // Offset relativo al lado izquierdo del vehículo
        Vector3 characterPosition = vehicle.transform.position + offset;
        characterPosition.y += verticalOffset; // Desplazamiento vertical
        character.transform.position = characterPosition;
        characterRigidbody.velocity = Vector3.zero; // Detener el movimiento del personaje
    }

    void SwitchControl()
    {
        // Cambiar entre control del personaje y el vehículo
        character.SetActive(isCharacterActive);
        vehicle.SetActive(!isCharacterActive);
        
        // Activar la cámara correspondiente
        characterCamera.SetActive(isCharacterActive);
        vehicleCamera.SetActive(!isCharacterActive);
    }
}



