﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowScript : MonoBehaviour
{
    [Tooltip("Configuration Scriptable Object")]
    public EnemyConfigObject configObject;
    [Tooltip("it's mooing")]
    bool moo;


    // Start is called before the first frame update
    void Start()
    {
        moo = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (RunHuasoRun.instance.endlessLevel)
        {
            float difficulty = RunHuasoRun.instance.elapsedTime / 30;
            if (difficulty < 1) difficulty = 1;
            if (difficulty > 5) difficulty = 5;
        
            transform.position -= transform.right * Time.deltaTime * difficulty;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
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

        if (collision.collider.tag == "Bounds")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !moo && collision.isTrigger)
        {
            moo = true;
            GetComponent<AudioSource>().PlayOneShot(configObject.spawnSound);
        }
    }
    /*
    private void OnTriggerExit2D(Collider2D collision)
    {
        moo = false;
    }*/
}
