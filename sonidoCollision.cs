using UnityEngine;

public class ReproducirSonidoAlChocar : MonoBehaviour
{
    public AudioClip sonidoColision;
    private AudioSource audioSource;

    private void Start()
    {
        // Asegurarse de que hay un AudioSource adjunto a este objeto
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // Si no hay un AudioSource, lo agregamos
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Comprobar si el objeto con el que colisionamos tiene el tag "Vehiculo"
        if (collision.gameObject.CompareTag("Vehiculo"))
        {
            // Reproducir el sonido de la colisión
            if (sonidoColision != null)
            {
                audioSource.PlayOneShot(sonidoColision);
            }
        }
    }
}
