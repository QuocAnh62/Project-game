using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSpawn : ManagerSpawnAndPool
{
    private int minY  /* = -3;*/ ;
    private int maxY  /* = 2;*/ ;

    private int minX = -6;
    private int maxX = 3;

    protected override void Start()
    {
        base.Start();

        minY =  Random.Range(-3, 0);
        maxY =  Random.Range(0, 2);
        CalculateSpawnGrid();
        StartCoroutine(LoopSpawnEnemy());
    }


    /* =========== Part Spawn Grid and Point sapwn enemy=========== */
    private void CalculateSpawnGrid()
    {
        for (int y = minY; y < maxY; y++)
        {
            for (int x = minX; x < maxX; x++)
            {
                SpawnGridAndPointSpawnEnemy(x, y,poolGrid); // Hanedle Spawn Grid
                if (x == maxX - 1) { SpawnGridAndPointSpawnEnemy(x + 1, y, poolPortalEnenmy); }  // Hanedle Spawn point to sapwn enemy
            }           
        }
    }
    protected void SpawnGridAndPointSpawnEnemy(float PosX, float PosY, List<GameObject> poolObj)
    {
        foreach (GameObject obj in poolObj)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                obj.transform.position = new Vector2(PosX, PosY);
                break;
            }
        }
    }


    /* =========== Part Spawn enemy=========== */

    private IEnumerator LoopSpawnEnemy()
    {
        yield return new WaitForSeconds(Random.Range(2, 5));
        while (true) 
        {
            SpawnEnemy();
            yield return new WaitForSeconds(Random.Range(6, 8));
        }
    }

    protected void SpawnEnemy()
    {
        foreach(GameObject portal in poolPortalEnenmy)
        {
            if (portal.activeInHierarchy)
            {
                foreach(GameObject enemy in poolEnemy)
                {
                    if (!enemy.activeInHierarchy)
                    {
                        enemy.SetActive(true);
                        enemy.transform.position = portal.transform.position;
                        break;
                    }
                }
            }
        }
    }
}
