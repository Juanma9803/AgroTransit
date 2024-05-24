using UnityEngine;
using UnityEngine.SceneManagement;

public class GameReset : MonoBehaviour
{
    public KeyCode resetKey = KeyCode.R; // Tecla para reiniciar el juego
    public string startingSceneName = "Main"; // Nombre de la escena inicial

    void Update()
    {
        // Verificar si se presiona la tecla especificada para reiniciar el juego
        if (Input.GetKeyDown(resetKey))
        {
            ResetGame();
        }
    }

    // Método para reiniciar el juego a su estado inicial
    public void ResetGame()
    {
        // Reiniciar la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        // Alternativamente, puedes reiniciar a una escena específica usando el nombre de la escena
        // SceneManager.LoadScene(startingSceneName);
    }
}
