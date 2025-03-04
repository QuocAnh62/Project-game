using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parameter_Manager : MonoBehaviour
{
    public static Parameter_Manager Instance;
    [Header("=== Player ===")]
    public float speedPlayer;

    [Header("=== Animal ===")]
    public float speedAnimal;
    public float animalPositionZ;
    public float animalPositionY;

    [Header("=== Feature Speed Up ===")]
    public float full_Stamina;
    public float current_Stamina;

    [Header("=== Spawn ===")]
    public int number_Car;


    private void Awake()
    {
        if (Instance == null) Instance = this;
    }


    private void Start()
    {
        speedPlayer = PlayerPrefs.GetFloat("Speed Player");
        number_Car = PlayerPrefs.GetInt("Number Car");
        speedAnimal = PlayerPrefs.GetFloat("Speed Animal");

        full_Stamina = PlayerPrefs.GetFloat("Stamina");
        current_Stamina = PlayerPrefs.GetFloat("Stamina");
    }

}
