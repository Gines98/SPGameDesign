using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory_EndScreen : MonoBehaviour
{
    public void ExitToMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}
