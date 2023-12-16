using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BullScript : EnemyComponent
{
    protected void Start()
    {
        base.Start();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            if (!collision.collider.GetComponent<HuasoScript>().beignHurt)
            {
                collision.collider.GetComponent<Rigidbody2D>().AddForce(new Vector2(collision.collider.GetComponent<HuasoScript>().speed * -configParameters.thrust, collision.collider.GetComponent<HuasoScript>().speed * 50));
                collision.collider.GetComponent<HuasoScript>().health -= configParameters.damage;
                if (collision.collider.GetComponent<HuasoScript>().health <= 0)
                {
                    collision.collider.GetComponent<HuasoScript>().health = 0;
                    collision.collider.GetComponent<HuasoScript>().alive = false;
                    RunHuasoRun.instance.LevelEnd(false);
                }
                if (configParameters.destructible)
                {
                    Destroy(gameObject);
                }
            }
        }

        if (collision.collider.tag == "Bounds")
        {          
            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        if(configParameters.spawnSound)
        GetComponent<AudioSource>().PlayOneShot(configParameters.spawnSound);
    }

    private void Update()
    {

        if(RunHuasoRun.instance.endlessLevel)
        {
            float difficulty = Time.timeSinceLevelLoad / 30;
            if (difficulty < 1) difficulty = 1;
            if (difficulty > 5) difficulty = 5;
            gameObject.GetComponent<Rigidbody2D>().velocity = transform.right * (-configParameters.speed * (difficulty/2));
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = transform.right * (-configParameters.speed);
        }

        //transform.position -= transform.right * configParameters.speed * Time.deltaTime;

    }

}
