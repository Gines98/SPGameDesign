using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PMenu : MonoBehaviour
{
    public GameObject ObjectPauseMenu;
    public bool Pause = false;
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        { 
            if(Pause == false)
            {
                ObjectPauseMenu.SetActive(true);
                Pause = true;

                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                AudioSource[] sonidos = FindObjectsOfType<AudioSource>();

                for(int i = 0; i < sonidos.Length; i++)
                {
                    sonidos[i].Pause();
                }
            }
            else if(Pause == true) 
            {
                Return();
            }
        }
    }

    public void Return()
    {
        ObjectPauseMenu.SetActive(false);
        Pause = false;
        BulletManager.Inst.isGamePaused = false;
        Time.timeScale = 1;
        Cursor.visible = true;
        Cursor.lockState= CursorLockMode.None;

        AudioSource[] sonidos = FindObjectsOfType<AudioSource>();

        for (int i = 0; i < sonidos.Length; i++)
        {
            sonidos[i].Play();
        }
    }

    public void ExitToMenu(string Main_Menu)
    {
        SceneManager.LoadScene(Main_Menu);
    }
}
