using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SetupGrid : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(CalculateSpawnGrid());
    }

    private IEnumerator CalculateSpawnGrid()
    {
        int minY = Random.Range(-2, 0);
        int maxY = Random.Range(0, 5);
        yield return new WaitForSeconds(0.05f);
        for (int y = minY; y <= maxY; y ++)
        {
            for (int x = -9; x < 3; x ++)
            {
                SpawnGridPrefab(x, y);
            }
           SpawnEnemyPrefab(y);
        }
    }


    private void SpawnGridPrefab(float PosX, float PosY)
    {
        foreach(GameObject grid in ManagerSpawnAndPool.instance.poolGrid)
        {
            if (!grid.activeInHierarchy)
            {
                grid.SetActive(true);
                grid.transform.position = new Vector2(PosX, PosY);
                break;
            }           
        }
    }

    private void SpawnEnemyPrefab(float PosY)
    {
        foreach(GameObject portal in ManagerSpawnAndPool.instance.poolPortalEnenmy)
        {
            if (!portal.activeInHierarchy)
            {
                portal.SetActive(true);
                portal.transform.position = new Vector2(4, PosY);
                break;
            }
        }
    }
}
