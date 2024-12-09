using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Specifications : MonoBehaviour
{
    public static Specifications Instance;

    public int dame_Enemy = 1;
    public int dame_Boss = 1;
    public int dame_Trap = 1;

    [Header("---- Infor Enemy ----")]
    public int health_Bat = 50;
    public int health_Ghost = 120;
    public int health_Slime = 75;
    public int health_MiniSlime = 50;

    [Header("---- Infor Boss Turtle ----")]
    public int health_turtle = 1500;
    public int health_Spikes = 30;


    [Header("---- Infor Boss Skull ----")]
    public int health_skull = 2000;
    public float speed_bullet = 15;
    public float speed_Skull = 550;

    [Header("---- Infor Platform Box ----")]
    public int health_box = 45;

    private void Awake()
    {
        if(Instance == null) { Instance = this; }
        else { Debug.Log("Not singleton"); }
    }


}
