using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;


public class Spawn_car : MonoBehaviour
{
    [SerializeField] private List<GameObject> car_Perfab;
    public Vector3 sizeSpawn;

    public Transform containCar;

    void Start()
    {
        SpawnCarsOnRoad();
    }

    void SpawnCarsOnRoad()
    {
        float distanceBetweenCars = sizeSpawn.z / (Parameter_Manager.Instance.number_Car + 1);

        for (int i = 1; i <= Parameter_Manager.Instance.number_Car; i++)
        {           
            Vector3 spawnPosition = new Vector3(Random.Range(7, sizeSpawn.x - 7), 0, i * distanceBetweenCars);


            int[] rotationAngles = { 0, 45, 90 };
            int randomIndex = Random.Range(0, rotationAngles.Length);
            float randomYRotation = rotationAngles[randomIndex];

            Quaternion spawnRotation = Quaternion.Euler(0, randomYRotation, 0);

            GameObject carPerfab = Instantiate(car_Perfab[Random.Range(0, car_Perfab.Count)], spawnPosition, spawnRotation);

            carPerfab.transform.parent = containCar;
        }
    } 
}
