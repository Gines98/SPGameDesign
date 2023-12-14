using System.Collections;
using System.Collections.Generic;
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
        /*if (bulletPrefab && (configParameters.enemyType == EnemyConfigObject.ENEMY_TYPE.MOVABLE_ENEMY_GUN ||
                             configParameters.enemyType == EnemyConfigObject.ENEMY_TYPE.STATIC_ENEMY_GUN) )
        {
            StartCoroutine(ShootCoroutine());
        }*/
        
    }

    protected IEnumerator ShootCoroutine()
    {
        BulletManager.Inst.Disparar(configParameters.damage, bulletSpawnPoint.transform.position, configParameters.gunSpeed, bulletSpawnPoint.transform.rotation , "Enemy", configParameters.bulletSprite);
        yield return new WaitForSeconds(configParameters.gunDelay);
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
