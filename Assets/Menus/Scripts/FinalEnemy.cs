using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalEnemy : MonoBehaviour
{
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnDestroy()
    {
        if (gameObject.GetComponent<EnemyComponent>().hp <= 0)
        {
            SceneManager.LoadScene("Victory_EndScreen");
        }
    }
}
