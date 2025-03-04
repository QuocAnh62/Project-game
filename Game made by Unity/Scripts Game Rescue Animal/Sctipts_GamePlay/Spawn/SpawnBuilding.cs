using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBuilding : MonoBehaviour
{
    [SerializeField] private Vector2 spawnBuilding;
    [SerializeField] private List<GameObject> housePerfab; // Need add list house perfab
    [SerializeField] private GameObject tilesLongPerfab;
    [SerializeField] private Transform containt; 

    void Start()
    {
        ManagerSpawnBuild();
        ManagerSpawnTilesLong();
    }

    private void ManagerSpawnBuild()
    {
        for(int col = -50; col < spawnBuilding.x; col += 200)
        {
            for(int row = 40 ; row <= spawnBuilding.y; row += 90)
            {
                if(col < 0)
                {
                    SpawnBuild(col, row, -90);
                }
                else
                {
                    SpawnBuild(col, row, 90);
                }
                
            }
        }
    }
    private void SpawnBuild(float col, float row, float rotationY)
    {
        GameObject house =
                    Instantiate(housePerfab[Random.Range(0, housePerfab.Count)], new Vector3(col, 0, row), Quaternion.Euler(0, rotationY, 0));

        house.transform.parent = containt;
    }


    private void ManagerSpawnTilesLong()
    {
        for (float col = -3.5f; col < spawnBuilding.x; col += 104.5f)
        {
            for (float row = 12; row <= spawnBuilding.y; row += 20)
            {

                if(col < spawnBuilding.x - 70f)
                {
                    GameObject tileLong = Instantiate(tilesLongPerfab, new Vector3(col, 0.2f, row), Quaternion.identity);
                    tileLong.transform.parent = containt;
                }
                
            }
        }
    }
}
