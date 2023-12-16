using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeImpact : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (!other.gameObject.GetComponent<HuasoScript>().beignHurt)
            {
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(other.gameObject.GetComponent<HuasoScript>().speed * -GetComponentInParent<EnemyComponent>().configParameters.thrust, other.gameObject.GetComponent<HuasoScript>().speed * 50));
                other.gameObject.GetComponent<HuasoScript>().health -= GetComponentInParent<EnemyComponent>().configParameters.damage;
                if (other.gameObject.GetComponent<HuasoScript>().health <= 0)
                {
                    other.gameObject.GetComponent<HuasoScript>().health = 0;
                    other.gameObject.GetComponent<HuasoScript>().alive = false;
                    RunHuasoRun.instance.LevelEnd(false);
                }
                if (GetComponentInParent<EnemyComponent>().configParameters.destructible)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
