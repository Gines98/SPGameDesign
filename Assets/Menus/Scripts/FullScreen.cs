using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FullScreen : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    public void PantallaCompleta(bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
    }

    public void CcambiarVolumen(float volumen) 
    {
        //audioMixer.SetFloat("Volumen", volumen);
        PlayerPrefs.SetFloat("Volumen", volumen);
        RunHuasoRun.instance.musicPlayer.volume = 0.1f * volumen;
    }

    public void CambiarCalidad(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }
}
