using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    
    public GameObject pausa;

    void Update()
    {
        // Verificar si se ha presionado la tecla Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Alternar entre pausar y reanudar el juego
            if (!BulletManager.Inst.isGamePaused)
                
                PausaGame();
        }
    }

    void PausaGame()
    { 
        // Pausar el juego (puedes agregar código adicional para pausar el tiempo, desactivar controles, etc.)
        Time.timeScale = 0f;
        BulletManager.Inst.isGamePaused = true;

        // Cargar la escena de pausa de manera aditiva (sin descargar la escena actual)
      pausa.SetActive(true);
    }

    public void ResumeGame()
    {
        // Reanudar el juego (puedes agregar código adicional para reanudar el tiempo, activar controles, etc.)
        Time.timeScale = 1f;
        BulletManager.Inst.isGamePaused = false;

        // Descargar la escena de pausa
        pausa.SetActive(false);
    }
}
