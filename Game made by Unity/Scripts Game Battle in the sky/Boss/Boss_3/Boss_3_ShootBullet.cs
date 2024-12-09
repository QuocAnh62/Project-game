using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boss_3_ShootBullet : MonoBehaviour
{
    public GameObject Player;
    public GameObject Bullet_Boss;
    public Transform local;
    public float speed_bullet;
    public float waitShoot;

    float cooldown = 6.5f;

    private void Update()
    {       
        if (cooldown <= 0)
        {
            Vector2 Dir = Player.transform.position - transform.position;          
            if (waitShoot <= 0)
            {      
                
                if (Dir.y <= 0.9f && Dir.y >= -0.9f)
                {               
                    StartCoroutine(Boss_3_Shoot());
                    waitShoot = 1f;
                }

            }

            if (Boss_3_ReceiveDame.currentHealth_Boss_3 <= 0 || Boss_ReceiveDame.currenthealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    private void FixedUpdate()
    {
        cooldown -= Time.deltaTime;
        waitShoot -= Time.deltaTime;
    }

    IEnumerator Boss_3_Shoot()
    {      
        GameObject bullet_boss = Instantiate(Bullet_Boss, local.position, local.rotation);
        Rigidbody2D rb = bullet_boss.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.right * -speed_bullet;
        yield break; 
    }

}
