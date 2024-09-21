using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O_Spawn_Item_Support : MonoBehaviour
{
    public GameObject[] ItemSupport;
    public float minSpawn;
    public float maxSpawn;
    public float waitSpawn_P_Bullet;


    private void Start()
    {
        StartCoroutine(Spawn_P_Bullet());
    }


    private void Update()
    {
        if (Boss_ReceiveDame.currenthealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Spawn_P_Bullet()
    {
        yield return new WaitForSeconds(13f);
        while (true)
        {
            float rage = Random.Range(minSpawn, maxSpawn);
            Vector3 position = new Vector3(transform.position.x, rage, 0);
            Instantiate(ItemSupport[Random.Range(0, ItemSupport.Length)], position, Quaternion.identity);
            yield return new WaitForSeconds(waitSpawn_P_Bullet);
        }
    }
}
