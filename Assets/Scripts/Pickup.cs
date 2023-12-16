using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            // Acciones específicas según el tag del objeto con el que colisiona el jugador.
            if (gameObject.CompareTag("Vida"))
            {
                // Suma 5 puntos de vida al jugador.
                collision.collider.GetComponent<HuasoScript>().SumarVida(5);
                PickUpSound.Inst.GetComponent<AudioSource>().Play();
            }
            else if (gameObject.CompareTag("Arma1"))
            {
                // Cambia el arma actual por otra (implementa la lógica en el script del jugador).
                collision.collider.GetComponent<HuasoScript>().CambiarArma("Arma1");
            }
            else if (gameObject.CompareTag("Arma2"))
            {
                // Cambia el arma actual por otra (implementa la lógica en el script del jugador).
                collision.collider.GetComponent<HuasoScript>().CambiarArma("Arma2");
            }
            else if (gameObject.CompareTag("Arma3"))
            {
                // Cambia el arma actual por otra durante 30 segundos (implementa la lógica en el script del jugador).
                collision.collider.GetComponent<HuasoScript>().ActivarArmaTemporal("Arma3", 30f);
            } 

            // Destruye el objeto después de la colisión.
            Destroy(gameObject);
        }
    }
}
