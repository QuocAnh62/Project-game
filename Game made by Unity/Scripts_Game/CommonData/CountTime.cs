using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountTime : MonoBehaviour
{
    [Header("---------- Time Spawn Items----------")]
    public float timeSpawnCoint;
    public float timeMinusSpawnCoint;
    public float Time_PlusSpeed_Item;
    public float waitImpactCoint;

    [Header("---------- Time Spawn Enemy ----------")]
    public float timeSpawnEnemy;
    public float timeMinusSpawnEnemy;
    public float timePlusSpeed_Enemy;
    public float waitImpactEnemy;


    [Header("---------- Time CoolDown Rocket ----------")]
    public float CurrentCoolDown;
    public float CoolDown;



    private Data_Enemy data_enemy;
    private Data data;
    void Start()
    {
        data_enemy = GameObject.FindAnyObjectByType<Data_Enemy>().GetComponent<Data_Enemy>();
        data = GameObject.FindObjectOfType<Data>().GetComponent<Data>();

        StartCoroutine(PlusSpeed_Coint());  
        StartCoroutine(PlusSpeed_Enemy());
        StartCoroutine(MinusTimeSpawn_Enemy());
        StartCoroutine(MinusSpawnCoint());
    }

    IEnumerator PlusSpeed_Coint()
    {
        yield return new WaitForSeconds(waitImpactCoint);
        while (true)
        {
            data.speed += data.Plus_Speed;
            yield return new WaitForSeconds(Time_PlusSpeed_Item);
        }
    }


    IEnumerator PlusSpeed_Enemy()
    {
        yield return new WaitForSeconds(waitImpactEnemy);
        while (true)
        {
            data_enemy.SpeedEnemy += data_enemy.plusSpeed_Enemy;
            yield return new WaitForSeconds(timePlusSpeed_Enemy);
        }
    }

    IEnumerator MinusTimeSpawn_Enemy()
    {
        yield return new WaitForSeconds(waitImpactEnemy);
        while (timeSpawnEnemy != 0.5)
        {           
            yield return new WaitForSeconds(timeMinusSpawnEnemy);
            timeSpawnEnemy -= 0.5f;
           // Debug.Log(timeSpawnEnemy);
        }
        timeSpawnEnemy = 0.70f;
        data_enemy.minSpanw = -11;
        data_enemy.maxSpanw = -27;
    }

    IEnumerator MinusSpawnCoint()
    {
        yield return new WaitForSeconds(waitImpactCoint);
        while (timeSpawnCoint != 1.5f)
        {
            yield return new WaitForSeconds(timeMinusSpawnCoint);
            timeSpawnCoint -= 0.5f; 
            //Debug.Log(timeSpawnCoint);
        }
        
    }
}
