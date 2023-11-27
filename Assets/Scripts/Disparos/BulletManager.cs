using System.Collections;
using System.Collections.Generic;
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

    public void Disparar(int power, Vector3 pos, float speed, Quaternion rotation, string ignoreTag, Sprite sprite = null)
    {
        GameObject disparo;
        if (balas.Count <= 0)
        {
            disparo = Instantiate(prefabBala);
        }
        else
        {
            disparo = balas[0];
            balas.Remove(disparo);
        }
        disparo.SetActive(true);
        disparo.transform.position = pos;
        disparo.transform.rotation = rotation;
        disparo.GetComponent<Rigidbody2D>().AddForce(disparo.transform.right * speed, ForceMode2D.Impulse);
        if (sprite != null)
        {
            disparo.GetComponent<SpriteRenderer>().sprite = sprite;
        }
        disparo.GetComponent<Bala>().power = power;
        disparo.GetComponent<Bala>().ignoreTag = ignoreTag;
    }
}
