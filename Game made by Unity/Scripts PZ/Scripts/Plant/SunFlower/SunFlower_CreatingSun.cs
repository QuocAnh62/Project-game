using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFlower_CreatingSun : MonoBehaviour
{
    private float timer = 3;
    public float coolDownCreatSun;

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Creat_Sunshine();
            timer = coolDownCreatSun;
        }
    }


    private void Creat_Sunshine() // Hanle create sunshine
    {
        foreach(GameObject sunShine in ManagerSpawnAndPool.instance.poolSun)
        {
            if (!sunShine.activeInHierarchy)
            {
                sunShine.SetActive(true);
                sunShine.transform.position = this.transform.position;
                break;  
            }
        }
    }
   
}
