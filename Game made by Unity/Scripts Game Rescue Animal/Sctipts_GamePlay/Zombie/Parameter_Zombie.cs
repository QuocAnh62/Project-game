using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parameter_Zombie : MonoBehaviour
{
    public static Parameter_Zombie Instance;

    public float speedZombie;

    public GameObject menu_Lose; // Need add gameObject Menu Lose

    public List<GameObject> inActive; // Need add gameObject JoyStick , alal stamina bar , Clock Speed

    private void Awake()
    {
        if(Instance == null) Instance = this;
    }
    private void Start()
    {
        speedZombie = PlayerPrefs.GetFloat("Speed Zombie");
    }
}
