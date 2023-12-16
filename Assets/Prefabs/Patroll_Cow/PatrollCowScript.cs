using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollCowScript : EnemyComponent
{
    private float difficulty;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        StartCoroutine(Patrolling());
       
    }

    public IEnumerator Patrolling()
    {
        int direction = 1;
        float idleAnimMinWait = Random.Range(1, 6);
        if (Random.Range(0, 2) == 1) 
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            direction = 1;
        } 
        else 
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            direction = -1;
        }

        float elapsedIdleSeconds = 0;
        
        
        do
        { 
            
            // We wait to the patroller to end its shooting animation (Which is the idle state) Once it finishes it repeats the cycle until the elapsed time in idle state is equal or higher the predefined time for the Idle State
            yield return new WaitForSeconds(gameObject.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip
                .length/2);
            yield return StartCoroutine(ShootCoroutine(direction, Time.deltaTime)); //We make it shoot the bullet at the middle of the animation
            yield return new WaitForSeconds(gameObject.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip
                .length/2);
            elapsedIdleSeconds += gameObject.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip
                .length;
            
        } while (elapsedIdleSeconds < idleAnimMinWait);
        
        
        float patrollSeconds = 0;
        gameObject.GetComponent<Animator>().SetBool("Idle", false);
        gameObject.GetComponent<Animator>().SetBool("Walk", true);
        do
        {
            patrollSeconds += Time.deltaTime;

            if (RunHuasoRun.instance.endlessLevel)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity =  transform.right * (direction * configParameters.speed * difficulty * 2);
            }
            else
            {
                gameObject.GetComponent<Rigidbody2D>().velocity =  transform.right * (direction * configParameters.speed);
            }


            //    transform.position += transform.right * Time.deltaTime * configParameters.speed * direction;
            
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
        if (RunHuasoRun.instance.endlessLevel)
        {
            difficulty = RunHuasoRun.instance.elapsedTime / 30;
            if (difficulty < 1) difficulty = 1;
            if (difficulty > 5) difficulty = 5;
        
            transform.position -= transform.right * Time.deltaTime * difficulty;
        }
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
