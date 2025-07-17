using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setup_Enemy : MonoBehaviour
{    
    public GameObject enemyPrefab;

    private void Start()
    {
         StartCoroutine(ADS());
       // StartCoroutine(SpawnEnemy());
    }

    //public IEnumerator SpawnEnemy()
    //{
    //    yield return new WaitForSeconds(Random.Range(2, 5));
    //    for (int i = 0; i < 10; i++)
    //    {
    //        GameObject enemy = Instantiate(enemyPrefab);
    //        enemy.transform.position = this.transform.position;           
    //        //foreach(GameObject porta       l in ManagerSpawnAndPool.instance.poolPortalEnenmy)
    //        //{
    //        //    if (portal.activeInHierarchy)
    //        //    {
    //        //        //Debug.Log("find portal");
    //        //        //SetPosEnemy();
    //        //        break;
    //        //    }
    //        //}
    //        yield return new WaitForSeconds(Random.Range(5,7));
    //    }      
    //}

    //private void SetPosEnemy()
    //{
    //    foreach(GameObject enemy in ManagerSpawnAndPool.instance.poolEnemy)
    //    {
    //        if (!enemy.activeInHierarchy)
    //        {
    //            enemy.SetActive(true);
    //            enemy.transform.position = Random.Range(0,);
    //            break;
    //        }
    //    }
    //}



    private IEnumerator ADS()
    {
        yield return new WaitForSeconds(2);
        while (true) 
        {
            if (Random.value < 0.7)
            {
                foreach(GameObject zombie in ManagerSpawnAndPool.instance.poolEnemy)
                {
                    if (!zombie.activeInHierarchy)
                    {
                        zombie.SetActive(true);
                        zombie.transform.position = this.transform.position;
                        break;
                    }
                }
            }          
            yield return new WaitForSeconds(Random.Range(3, 5));
        }
    }
}
