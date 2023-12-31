using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistola : MonoBehaviour
{
    [SerializeField] float shootOffset;
    [SerializeField] int power;
    [SerializeField] float speed;
    [SerializeField] Sprite bala;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direccion = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
        float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(angulo, Vector3.forward);
        if (Input.GetMouseButtonUp(0))
        {
            BulletManager.Inst.Disparar(power, this.transform.position + this.transform.rotation * (Vector3.right * shootOffset), speed, this.transform.rotation, "Player", bala);
        }
    }

    public void ChangeGun(float offset, int bulletPower, float bulletSpeed, Sprite bullet)
    {
        shootOffset = offset;
        power = bulletPower;
        speed = bulletSpeed;
        bala = bullet;
    }
}
