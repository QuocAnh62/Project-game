using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAnimalOther : MonoBehaviour
{
    [SerializeField] private List<GameObject> animal_Perfab;
    private int numberAnimal = 5;
    public Vector3 sizeSpawn;

    public Transform containCar;

    void Start()
    {
        SpawnCarsOnRoad();
    }

    void SpawnCarsOnRoad()
    {
        for (int i = 1; i <= numberAnimal; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(7, sizeSpawn.x - 7), 0.2f,i*10 + Random.Range(370,730));

            GameObject carPerfab = 
                Instantiate(animal_Perfab[Random.Range(0, animal_Perfab.Count)], spawnPosition, Quaternion.identity);

            carPerfab.transform.parent = containCar;
        }
    }
}
