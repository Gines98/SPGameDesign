using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HUD : MonoBehaviour
{
    public Image barraVida;

    public Text bullets;

    // Update is called once per frame
    void Update()
    {
     
        barraVida.fillAmount = RunHuasoRun.instance.playerGameObject.GetComponent<HuasoScript>().health / 100f;
        bullets.text = RunHuasoRun.instance.pistolaGameObject.GetComponent<Pistola>().disparos_restantes.ToString();
        
    }
}
