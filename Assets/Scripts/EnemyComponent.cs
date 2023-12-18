using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyComponent : MonoBehaviour
{
    public EnemyConfigObject configParameters;
    public int hp;
    public GameObject bulletSpawnPoint;
    public GameObject bulletPrefab;
    public int speed;
    // Start is called before the first frame update
    protected void Start()
    {
        hp = configParameters.health;
        speed = configParameters.speed;
        if (GetComponent<Rigidbody2D>())
        {
            if (RunHuasoRun.instance.endlessLevel)
            {
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            }
            else
            {
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
        }

        /*if (bulletPrefab && (configParameters.enemyType == EnemyConfigObject.ENEMY_TYPE.MOVABLE_ENEMY_GUN ||
                             configParameters.enemyType == EnemyConfigObject.ENEMY_TYPE.STATIC_ENEMY_GUN) )
        {
            StartCoroutine(ShootCoroutine());
        }*/
        
    }

    protected IEnumerator ShootCoroutine(int direction, float secondsDelay)
    {
        BulletManager.Inst.Disparar(configParameters.damage, bulletSpawnPoint.transform.position, configParameters.gunSpeed * direction, bulletSpawnPoint.transform.rotation , "Enemy", configParameters.bulletSprite, bulletPrefab);
        yield return new WaitForSeconds(secondsDelay);
        //yield return new WaitForSeconds(configParameters.gunDelay);
        //StartCoroutine(ShootCoroutine());
    }

    // Update is called once per frame
    protected void Update()
    {
        /*bulletSpawnPoint.transform.LookAt(FindObjectOfType<HuasoScript>().transform.position);

        if (configParameters.enemyType == EnemyConfigObject.ENEMY_TYPE.MOVABLE_ENEMY_GUN ||
            configParameters.enemyType == EnemyConfigObject.ENEMY_TYPE.MOVABLE_ENEMY_NOGUN)
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }*/
    }
}
