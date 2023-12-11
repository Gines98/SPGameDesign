using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistola : MonoBehaviour
{
    float shootOffset;
    int power;
    float speed;
    Sprite bala;
    [SerializeField] Pistola_Tipo pistolaDefault;
    int disparos_restantes;
    // Start is called before the first frame update
    void Start()
    {
        ChangeGun(pistolaDefault);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direccion = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
        float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(angulo, Vector3.forward);
        this.transform.GetChild(0).GetComponent<SpriteRenderer>().flipY = direccion.x < 0;
        if (Input.GetMouseButtonUp(0))
        {
            BulletManager.Inst.Disparar(power, this.transform.position + this.transform.rotation * (Vector3.right * shootOffset), speed, this.transform.rotation, "Player", bala);
            disparos_restantes -= 1;
            if (disparos_restantes <= 0)
            {
                ChangeGun(pistolaDefault);
            }
        }
    }

    public void ChangeGun(float offset, int bulletPower, float bulletSpeed, Sprite bullet, int disparos)
    {
        shootOffset = offset;
        power = bulletPower;
        speed = bulletSpeed;
        bala = bullet;
        disparos_restantes = disparos;
    }

    public void ChangeGun(Pistola_Tipo pistola_tipo)
    {
        shootOffset = pistola_tipo.offset;
        power = pistola_tipo.power;
        speed = pistola_tipo.speed;
        bala = pistola_tipo.bala;
        disparos_restantes = pistola_tipo.disparos;
    }
}
