using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    [Header("---------- Player ----------")]
    public float speed_x;
    public float speed_y;



    [Header("----------Power Of Player ----------")]
    public float speed_bullet;
    public float speed_Pink_bullet;
    public float speed_rocket;
    public int Dame_Player = 1;
    public int Dame_Pink_Bullet = 2;
    public int Dame_Rocket = 20;

    [Header("---------- health ----------")]
    public float maxHealth_Player;
   
    public float maxHealth_PlayerBoss;
    
    public float notdead_Cooldown;
    public float notdead;


    [Header("---------- Other ----------")]
    public float speed;
    public float Plus_Speed;

    [Header("---------- Scale Spawn Item ----------")]
    public float MinSpawn;
    public float MaxSpawn;

   
   
}
