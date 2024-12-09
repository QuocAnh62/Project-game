using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet_State : MonoBehaviour
{
    public Transform AttackPoint;
    public float Radius = 0.1f;
    public int Bullet_Dame;
    public LayerMask enemyLayer;

    void Update()
    {
        BulletDame();
  
    }

    private void BulletDame()
    {
        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(AttackPoint.position, Radius, enemyLayer);

        foreach (Collider2D enemy in hitEnemy)
        {
            if (enemy.CompareTag("Ghost")) continue;

            if (enemy.CompareTag("Tile")) Destroy(this.gameObject);
          
            Health health = enemy.GetComponent<Health>();

            if(health != null && Data_Player.Instance.health_Player.IsAlive)
            {               
                health.Enemy_GetDameBullet(Bullet_Dame);
                Destroy(gameObject);               
            }
                      
        }
    }
   

    private void OnTriggerEnter2D(Collider2D collision)
    {    
        if (collision.gameObject.CompareTag("Tile"))
        {
            Destroy(this.gameObject);
        }
                  
    }  

    private void OnDrawGizmosSelected()
    {
        if (AttackPoint == null) return;
        Gizmos.DrawWireSphere(AttackPoint.position, Radius);
    }

}
