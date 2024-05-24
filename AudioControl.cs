using UnityEngine;

public class AudioControl : MonoBehaviour 
{
    public static AudioControl instance; // Referencia estática al AudioManager

    public AudioSource audioSource;

    void Awake()
    {
        // Asegúrate de que solo haya una instancia de AudioManager en la escena
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // No destruir este objeto al cargar una nueva escena
        }
        else
        {
            Destroy(gameObject); // Si ya hay una instancia, destruir este objeto para evitar duplicados
            return;
        }

        // Asegúrate de que el AudioSource esté configurado en bucle para que la canción se reproduzca permanentemente.
        audioSource.loop = true;
        // Reproducir la música al inicio
        PlayMusic();
    }

    void Update()
    {
        // Si se presiona la tecla M, inicia o reanuda la reproducción de la música.
        if (Input.GetKeyDown(KeyCode.M))
        {
            PlayMusic();
        }
        // Si se presiona la tecla N, detiene la música.
        if (Input.GetKeyDown(KeyCode.N))
        {
            StopMusic();
        }
    }

    public void PlayMusic()
    {
        // Comprueba si el audio ya está reproduciéndose para evitar iniciar una segunda instancia.
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void StopMusic()
    {
        // Detiene la música.
        audioSource.Stop();
    }
}
