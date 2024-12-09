using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Data_Player : MonoBehaviour
{
    public static Data_Player Instance;
    [Header("-------- Player -------")]    
    public SpriteRenderer artPlayer;
    public Transform trsForm_Player;
    public Rigidbody2D rb;
    public Animator anim_Player;

    [Header("-------- Collider -------")]
    public CapsuleCollider2D capsuleColli;
    public BoxCollider2D boxcolli;

    [Header("-------- Weapon -------")]
    public GameObject weapon_Melee;
    public GameObject weapon_Gun;
    public Deset_Eagle deset_eagle;
    public Ak47 ak47;

    [Header("-------- Health -------")]
    public Health_Player health_Player;

    private void Awake()
    {
        if(Instance == null) Instance = this;
        else { Debug.Log("Not singleton"); }
    }
}
