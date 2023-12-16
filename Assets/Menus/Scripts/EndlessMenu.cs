using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndlessMenu : MonoBehaviour
{
    public void Endless()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void Salir()
    {
        Debug.Log("Exit...");
        Application.Quit();
    }
}
