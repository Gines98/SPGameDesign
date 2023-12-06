using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Create Enemy Config", order = 2)]
public class EnemyConfigObject : ScriptableObject
{
    public enum ENEMY_TYPE
    {
        STATIC_ENEMY_NOGUN,
        MOVABLE_ENEMY_NOGUN,
        STATIC_ENEMY_GUN,
        MOVABLE_ENEMY_GUN,
        END_LEVEL_BOSS

    };
    [HideInInspector]
    public bool isMovable = false;
    [Tooltip("The health of the enemy")]
    public int health;
    [Tooltip("Set ups the enemy type")]    
    public ENEMY_TYPE enemyType = ENEMY_TYPE.STATIC_ENEMY_NOGUN;
    [Tooltip("Damage dealed by the enemy to the player")]
    public int damage = 1;
    [Tooltip("Check if the enemy is destroyed after collision")]
    public bool destructible = true;
    [ConditionalHide("isMovable")]
    [Tooltip("Sets up the enemy speed. Only works for Movable Enemies")]
    public int speed = 3;
    [Tooltip("Sets up the enemy gun speed. Only works for Enemies with guns")]
    public int gunSpeed = 3;
    [Tooltip("Sets up a waiting time between bullets. NEVER GO TO ZERO")]
    public int gunDelay = 1;
    [ConditionalHide("isMovable")]
    [Tooltip("Sets up the force used by the enemy to hit the player")]
    public int thrust = 150;
    [Tooltip("Sets up a sound when this enemy is instantiated in the scene")]
    public AudioClip spawnSound;
    [Tooltip("Sets up the sprite of the bullet associated to this enemy's gun")]
    public Sprite bulletSprite;

    private void OnValidate()
    {
        if(enemyType == ENEMY_TYPE.MOVABLE_ENEMY_NOGUN || enemyType == ENEMY_TYPE.MOVABLE_ENEMY_GUN)
        {
            isMovable = true;
        }
        else
        {
            isMovable = false;
        }
    }

    public void ReturnDefaultValues()
    {
        isMovable = false;
        enemyType = ENEMY_TYPE.STATIC_ENEMY_NOGUN;
        damage = 1;
        destructible = true;
        speed = 3;
        spawnSound = null;
        thrust = 150;
        gunDelay = 1;
        gunSpeed = 3;
        health = 10;
    }
}
