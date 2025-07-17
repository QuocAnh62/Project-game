using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Setup_Grid : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(CalculateSpawnGrid());
    }

    private IEnumerator CalculateSpawnGrid()
    {
        //int minY = Random.Range(-3, 0);
        //int maxY = Random.Range(0, 2);
        yield return new WaitForSeconds(0.05f);
        for (int y = -3; y <= 1; y ++)
        {
            for (int x = -6; x < 3; x ++)
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

    private void SpawnEnemyPrefab(float PosY) // SpawnPortal this portal will active enenmy
    {
        foreach(GameObject portal in ManagerSpawnAndPool.instance.poolPortalEnenmy)
        {
            if (!portal.activeInHierarchy)
            {
                portal.SetActive(true);
                portal.transform.position = new Vector2(3, PosY);
                break;
            }
        }
    }
}
