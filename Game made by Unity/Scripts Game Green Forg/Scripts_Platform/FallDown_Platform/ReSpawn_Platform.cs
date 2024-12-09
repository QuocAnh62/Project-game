using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ReSpawn_Platform : MonoBehaviour
{   
    public GameObject SpawnFallDownPlatform;
    

    IEnumerator RespawnPlatform(float wait)
    {
        yield return new WaitForSeconds(wait);        
        GameObject spawn = Instantiate(SpawnFallDownPlatform, transform.position, transform.rotation);  
        spawn.gameObject.transform.parent = transform;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == Data_Player.Instance.boxcolli) StartCoroutine(RespawnPlatform(2f));
        else return;
    }


}
