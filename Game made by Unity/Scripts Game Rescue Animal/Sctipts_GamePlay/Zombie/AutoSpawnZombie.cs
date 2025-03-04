using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSpawnZombie : MonoBehaviour
{
    [SerializeField] private Vector2 roomSize;
    [SerializeField] private GameObject zombie_Perfab;
    [SerializeField] private Transform container;

    private void Start()
    {
        Calculation_SpawnZombie();
    }


    private void Calculation_SpawnZombie()
    {
        for (int x = 4; x < 100; x += 10)
        {
            SpawnZombie(x);           
        }
    }


    private void SpawnZombie(float x)
    {
        GameObject zombie = Instantiate(zombie_Perfab, new Vector3(x, 0, -150), Quaternion.identity);

        zombie.transform.parent = container;
        
    }
}
