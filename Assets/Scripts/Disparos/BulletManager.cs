using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public static BulletManager Inst { get; private set; }
    public List<GameObject> balas;
    [SerializeField] GameObject prefabBala;
    // Start is called before the first frame update
    void Start()
    {
        if (Inst == null)
        {
            Inst = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Disparar(int power, Vector3 pos, float speed, Quaternion rotation, string ignoreTag, Sprite sprite = null, GameObject specificPrefab = null)
    {
        GameObject disparo;
        if (balas.Count <= 0)
        {
            if (specificPrefab)
            {
                disparo = Instantiate(specificPrefab);
            }
            else
            {
                disparo = Instantiate(prefabBala);
            }
            
        }
        else
        {
            if (!specificPrefab)
            {
                if (balas.Any(x => x == prefabBala))
                {
                    disparo = balas.Where(x=> x == prefabBala).ElementAt(0);
                    balas.Remove(disparo);
                }
                else
                {
                    disparo = Instantiate(prefabBala);
                }
            }
            else
            {
                if (balas.Any(x => x == specificPrefab))
                {
                    disparo = balas.Where(x=> x == specificPrefab).ElementAt(0);
                    balas.Remove(disparo);
                }
                else
                {
                    disparo = Instantiate(specificPrefab);
                }
            }

        }
        disparo.SetActive(true);
        disparo.transform.position = pos;
        disparo.transform.rotation = rotation;
        disparo.GetComponent<Rigidbody2D>().AddForce(disparo.transform.right * speed, ForceMode2D.Impulse);
        if (sprite != null)
        {
            disparo.GetComponent<SpriteRenderer>().sprite = sprite;
            disparo.GetComponent<SpriteRenderer>().color = Color.white;
        }
        disparo.GetComponent<Bala>().power = power;
        disparo.GetComponent<Bala>().ignoreTag = ignoreTag;
    }
}
