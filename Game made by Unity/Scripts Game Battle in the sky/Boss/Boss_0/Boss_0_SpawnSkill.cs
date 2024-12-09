using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boss_0_SpawnSkill : MonoBehaviour
{
    public GameObject Shot;
    public GameObject BulletBoss;
    public Transform local;
  
    public float wait;
    private void Start()
    {
        StartCoroutine(SpawnBullet());      
    }

    private void Update()
    {
        if (Boss_ReceiveDame.currenthealth <= 0 || Boss_0_ReceiveDame.currentHealth_Boss_0 <= 0 )      
            Destroy(Shot);       
    }

        // Spawn Bullet
    IEnumerator SpawnBullet()
    {
        yield return new WaitForSeconds(6f);       
            while (true)
            {
                yield return new WaitForSeconds(wait);
                Instantiate(BulletBoss, local.position, local.rotation);       
            }
    }  
}
