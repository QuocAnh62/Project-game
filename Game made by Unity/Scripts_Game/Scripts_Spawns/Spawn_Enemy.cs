using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Enemy : MonoBehaviour
{
    public GameObject[] Enemy;
    public GameObject Spawnenemy;
    public float waitSpawnEnemy;

    private Data data;
    private Data_Enemy data_enemy;
    private CountTime countTime;
    float currentHealth_Player;
    void Start()
    {
        data_enemy = GameObject.FindAnyObjectByType<Data_Enemy>().GetComponent<Data_Enemy>();       
        countTime = GameObject.FindAnyObjectByType<CountTime>().GetComponent<CountTime>();
         StartCoroutine(SpawnEnemy());              
    }
  
    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(waitSpawnEnemy);
        while (true)
        {
            float local = Random.Range(data_enemy.minSpanw, data_enemy.maxSpanw);
            var position = new Vector3(transform.position.x, local, 0);
            Instantiate(Enemy[Random.Range(0, Enemy.Length)], position, Quaternion.identity);
            yield return new WaitForSeconds(countTime.timeSpawnEnemy);
        }
    }
}
