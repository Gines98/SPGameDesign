using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    // Start is called before the first frame update
    public int power;
    public string ignoreTag;
    void Start()
    {
        if (BulletManager.Inst.balas.Contains(this.gameObject))
        {
            BulletManager.Inst.balas.Remove(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.gameObject.GetComponent<SpriteRenderer>().isVisible)
        {
            BulletManager.Inst.balas.Add(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != ignoreTag && !collision.isTrigger)
        {
            BulletManager.Inst.balas.Add(this.gameObject);
            Debug.Log(collision.gameObject.name);
            this.gameObject.SetActive(false);
        }
    }
}
