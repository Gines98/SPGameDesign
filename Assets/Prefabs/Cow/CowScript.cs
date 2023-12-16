﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowScript : EnemyComponent
{

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        StartCoroutine(ThrowObject());
    }

    IEnumerator ThrowObject()
    {
        do
        {
            GetComponent<Animator>().SetTrigger("Shoot");
            yield return new WaitForSeconds(0.25f);
            yield return  StartCoroutine(ShootCoroutine(1,configParameters.gunDelay));
            //yield return new WaitForSeconds(GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.length / 2);
        } while (true);

    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
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

        if (collision.collider.tag == "Bounds")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
    /*
    private void OnTriggerExit2D(Collider2D collision)
    {
        moo = false;
    }*/
}
