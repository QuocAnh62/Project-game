using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data_Enemy : MonoBehaviour
{
    [Header("---------- Health Enemy ----------")]
    public float maxHealth_Enemy;
    public float currentHealth_Enemy;
    public int Dame_Enemy;


    [Header("---------- Speed Enemy ----------")]
    public float SpeedEnemy;
    public float plusSpeed_Enemy;
    public float minSpanw;
    public float maxSpanw;

    [Header("---------- Dame Boss ----------")]
    public int Dame_Boss;
    public int Dame_Collision;
    public int Dame_Rocket_Boss;

    [Header("---------- Health Boss ----------")]
    public float maxHealth_Boss_0;

    public float maxHealth_Boss_1;

    public float maxHealth_Boss_2;

    public float maxHealth_Boss_3;

    public float maxHealth_Boss_4;

    public float maxHealth_Boss_5;

}
