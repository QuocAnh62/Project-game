using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Bullet_Skull : MonoBehaviour
{  
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tile"))
            Destroy(this.gameObject);

        // if Skull collison with player and health boss must be great 0. Boss will minus health player
        if (collision.gameObject.CompareTag("Player") && Manager_Boss_Skull.Instance.state_Skull.Health_Boss)
        {
            Data_Player.Instance.health_Player.BossSkull_MinusHealthPlayer(Specifications.Instance.dame_Boss);
            Debug.Log("Skull Attack");
            Destroy(this.gameObject);
        }
    }   

}
