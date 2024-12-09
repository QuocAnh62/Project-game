using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Boss : MonoBehaviour
{  
    [SerializeField] protected GameObject Bullet_skull_perfab;
    [SerializeField] private Transform hold_Bullet;
    protected Vector3 Dir;

   

    protected void calculate()
    {
        Dir =  (Data_Player.Instance.trsForm_Player.position - transform.position).normalized;
        float rot = Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg;
        //Debug.Log("cacul " + Dir);
       transform.rotation = Quaternion.Euler(0, 0, rot + 180);
    }



    /***************** Skill Boss ***********************/
    // Skill_1
    protected void fireBall()
    {
        StartCoroutine(two_Ball());
    }

    private IEnumerator two_Ball()
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject bullet = Instantiate(Bullet_skull_perfab, transform.position, Quaternion.identity);
            bullet.transform.parent = hold_Bullet;
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(Dir.x, Dir.y).normalized * 17f;
            yield return new WaitForSeconds(0.3f);
        }
    }


    /****************************************************/
    // Skill_2
    protected void three_fireBall()
    {
        StartCoroutine(fire());

    }
    private IEnumerator fire()
    {
        for (int n = 0; n < 2; n++)
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject bullet = Instantiate(Bullet_skull_perfab, transform.position, Quaternion.identity);
                bullet.transform.parent = hold_Bullet;

                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.velocity = new Vector2(Dir.x, Dir.y).normalized * Specifications.Instance.speed_bullet;

                yield return new WaitForSeconds(0.4f);
            }
            yield return new WaitForSeconds(0.3f);
        }
        
    }



    // Skill_3
    protected void oneShoot_3Ball()
    {
        StartCoroutine(SpawnBullets()); 
    }

    private IEnumerator SpawnBullets()
    {
        for (int i = 0; i < 3; i++)
        {
            SpawnBullet(0);  // Add angle Bullet  
            SpawnBullet(30);
            SpawnBullet(330);
            yield return new WaitForSeconds(0.8f);
        }       
    }

    private void SpawnBullet(float angle)
    {        
        Vector2 bulletDirection = Quaternion.Euler(0, 0, angle) * Dir;

        GameObject bullet = Instantiate(Bullet_skull_perfab, transform.position, Quaternion.identity);
        bullet.transform.parent = hold_Bullet;

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = bulletDirection * Specifications.Instance.speed_bullet;
    }



    // Skill_4
    protected void ball_circle()
    {
        for (int i = 0; i < 18; i++)
        {
            
            float angle = i * 20; 
            
            // calcul Direction
            Vector2 direction = 
                new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)); 

            // Calculate Position Spawn
            Vector2 spawnPosition = (Vector2)transform.position + direction * 2f;

            // Spawn Bullet
            GameObject bullet = Instantiate(Bullet_skull_perfab, spawnPosition, Quaternion.identity);
            bullet.transform.parent = hold_Bullet;

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = direction * Specifications.Instance.speed_bullet; 
        }
    }
    /********************************************************/

}

