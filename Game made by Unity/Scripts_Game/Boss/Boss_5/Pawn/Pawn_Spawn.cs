using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn_Spawn : MonoBehaviour
{
    public GameObject SpawnPawn;
    public Transform localPawn;
    public float timeSpawnPawn;
    public void Pawn()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(timeSpawnPawn);
        if (Pawn_Receivedame.currentHealt_Pawn <= 0) // This line spawn actually 1 Pawn  // If Don't have this line scripts can spawn many Pawn 
        {
            Instantiate(SpawnPawn, localPawn.position, localPawn.rotation);
        }
    }

    private void Update()
    {
        if(Boss_5_ReceiveDame.currentHealth_Boss_5 <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
