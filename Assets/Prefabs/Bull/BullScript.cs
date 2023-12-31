﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullScript : MonoBehaviour
{
    [Tooltip("Configuration Scriptable Object")]
    public EnemyConfigObject configObject;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            if (!collision.collider.GetComponent<HuasoScript>().beignHurt)
            {
                collision.collider.GetComponent<Rigidbody2D>().AddForce(new Vector2(collision.collider.GetComponent<HuasoScript>().speed * -configObject.thrust, collision.collider.GetComponent<HuasoScript>().speed * 50));
                collision.collider.GetComponent<HuasoScript>().health -= configObject.damage;
                if (collision.collider.GetComponent<HuasoScript>().health <= 0)
                {
                    collision.collider.GetComponent<HuasoScript>().health = 0;
                    collision.collider.GetComponent<HuasoScript>().alive = false;
                    RunHuasoRun.instance.LevelEnd(false);
                }
                if (configObject.destructible)
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
        if(configObject.spawnSound)
        GetComponent<AudioSource>().PlayOneShot(configObject.spawnSound);
    }

    private void Update()
    {
        if(RunHuasoRun.instance.endlessLevel)
        {
            float difficulty = Time.timeSinceLevelLoad / 30;
            if (difficulty < 1) difficulty = 1;
            if (difficulty > 5) difficulty = 5;
            transform.position -= transform.right * configObject.speed * Time.deltaTime * (difficulty / 2);
        }
        else
        {
            transform.position -= transform.right * configObject.speed * Time.deltaTime;
        }
        
        
    }

}
