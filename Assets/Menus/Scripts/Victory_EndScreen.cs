using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory_EndScreen : MonoBehaviour
{
    public TMP_Text scoreText;

    private void Start()
    {
        if (RunHuasoRun.instance)
        {
            RunHuasoRun.instance.StopAllCoroutines();
            scoreText.text = "Score Obtained: " + RunHuasoRun.instance.score.ToString();
        }
        else
        {
            scoreText.gameObject.SetActive(false);
        }
    }

    public void ExitToMenu()
    {
        StartCoroutine(ExitCoroutine());
    }

    IEnumerator ExitCoroutine()
    {
        if (RunHuasoRun.instance)
        {
            Destroy(RunHuasoRun.instance.gameObject);
            yield return new WaitForFixedUpdate();
            RunHuasoRun.instance = null;
            yield return new WaitForFixedUpdate();
        }

        yield return new WaitForFixedUpdate();

        SceneManager.LoadScene("Main_Menu");
    }
}
