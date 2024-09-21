using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_RandomwCoint : MonoBehaviour
{
    public GameObject[] cointPerfab;
    public GameObject SpawnCoint;
    public float waitSpawnCoint;

    private Data_Enemy data_enemy;  
    private CountTime countTime;
    float currentHealth_Player;
    private void Start()
    {
        data_enemy = GameObject.FindObjectOfType<Data_Enemy>().GetComponent<Data_Enemy>();     
        countTime = GameObject.FindObjectOfType<CountTime>().GetComponent<CountTime>();       
         StartCoroutine(SpawnCoints());       
    }
  

        IEnumerator SpawnCoints()
        {      
            yield return new WaitForSeconds(waitSpawnCoint);
            while (true)
            {
                float wanted = Random.Range(data_enemy.minSpanw, data_enemy.maxSpanw);
                var position = new Vector3(transform.position.x, wanted, 0);
                Instantiate(cointPerfab[Random.Range(0, cointPerfab.Length)], position, Quaternion.identity);
                yield return new WaitForSeconds(countTime.timeSpawnCoint);
            }        
        }    

}
