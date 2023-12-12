using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollCowScript : EnemyComponent
{

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        StartCoroutine(Patrolling());
       
    }

    public IEnumerator Patrolling()
    {
        int direction = 1;
        if (Random.Range(0, 2) == 1) 
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            direction = 1;
        } 
        else 
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            direction = -1;
        } 
        yield return new WaitForSeconds(Random.Range(1, 6));
        float patrollSeconds = 0;
        gameObject.GetComponent<Animator>().SetBool("Idle", false);
        gameObject.GetComponent<Animator>().SetBool("Walk", true);
        do
        {
            patrollSeconds += Time.deltaTime;

                transform.position += transform.right * Time.deltaTime * configParameters.speed * direction;
            
            yield return new WaitForEndOfFrame();
        } while (patrollSeconds < 3);

        gameObject.GetComponent<Animator>().SetBool("Idle", true);
        gameObject.GetComponent<Animator>().SetBool("Walk", false);

        StartCoroutine(Patrolling());
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
    
}
