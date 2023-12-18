using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private void Update()
    {
        if (RunHuasoRun.instance.endlessLevel)
        {
            float difficulty = RunHuasoRun.instance.elapsedTime / 30;
            if (difficulty < 1) difficulty = 1;
            if (difficulty > 5) difficulty = 5;

            transform.position -= transform.right * Time.deltaTime * difficulty;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Acciones espec�ficas seg�n el tag del objeto con el que colisiona el jugador.
            if (gameObject.CompareTag("Vida"))
            {
                // Suma 5 puntos de vida al jugador.
                other.gameObject.GetComponent<HuasoScript>().SumarVida(5);
                PickUpSound.Inst.GetComponent<AudioSource>().Play();
            }
            else if (gameObject.CompareTag("Arma1"))
            {
                // Cambia el arma actual por otra (implementa la l�gica en el script del jugador).
                other.gameObject.GetComponent<HuasoScript>().CambiarArma("Arma1");
            }
            else if (gameObject.CompareTag("Arma2"))
            {
                // Cambia el arma actual por otra (implementa la l�gica en el script del jugador).
                other.gameObject.GetComponent<HuasoScript>().CambiarArma("Arma2");
            }
            else if (gameObject.CompareTag("Arma3"))
            {
                // Cambia el arma actual por otra durante 30 segundos (implementa la l�gica en el script del jugador).
                other.gameObject.GetComponent<HuasoScript>().ActivarArmaTemporal("Arma3", 30f);
            } 

            // Destruye el objeto despu�s de la colisi�n.
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
