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
    void Start()
    {
        hp = configParameters.health;
        speed = configParameters.speed;
        if (bulletPrefab)
        {
            StartCoroutine(ShootCoroutine());
        }
        
    }

    IEnumerator ShootCoroutine()
    {
        BulletManager.Inst.Disparar(configParameters.damage, bulletSpawnPoint.transform.position, configParameters.gunSpeed, bulletSpawnPoint.transform.rotation , "Enemy", configParameters.bulletSprite);
        yield return new WaitForSeconds(configParameters.gunDelay);
        StartCoroutine(ShootCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        bulletSpawnPoint.transform.LookAt(FindObjectOfType<HuasoScript>().transform.position);
    }
}
