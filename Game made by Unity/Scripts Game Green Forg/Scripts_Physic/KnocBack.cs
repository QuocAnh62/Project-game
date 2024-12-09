using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnocBack : MonoBehaviour
{
    public static KnocBack instance;
    float thrust = 28;
    float TimeDelayThrust = 0.25f;

    private void Awake()
    {
        if(instance == null) instance = this;
    }
    public void KnocB(Rigidbody2D rb, GameObject Enemy, Transform Player)
    {
        if (rb != null)
        {
            Vector2 difference = (Enemy.transform.position - Player.position).normalized * thrust; // caculate knockback
            rb.AddForce(difference, ForceMode2D.Impulse);
            StartCoroutine(StopKnockback(rb, TimeDelayThrust));
        }
        else Debug.Log("Null");       
    }
    IEnumerator StopKnockback(Rigidbody2D enemyRb, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (enemyRb != null)
            enemyRb.velocity = Vector2.zero; // Stop KnocBack
    }
}
