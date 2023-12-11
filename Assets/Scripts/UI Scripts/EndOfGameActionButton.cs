using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfGameActionButton : MonoBehaviour
{
    public void NextLevel(string scene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene, UnityEngine.SceneManagement.LoadSceneMode.Single);
    }

    public void EndGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main_Menu", UnityEngine.SceneManagement.LoadSceneMode.Single);
    }
}
