using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nueva Pistola", menuName = "ScriptableObjects/Create new Pistola")]
public class Pistola_Tipo : ScriptableObject
{
    public int power;
    public float offset;
    public float speed;
    public Sprite bala;
    public Sprite pistola;
    public int disparos;
}
