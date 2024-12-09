using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn_Shoot_1 : MonoBehaviour
{
    public GameObject Bullet_Pawn;
    public Transform Bullet_local_1;
    public float speedBullet;
    public float timeWait;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private void Update()
    {
        if (Boss_ReceiveDame.currenthealth <= 0)
        {
            Destroy(GetComponent<Pawn_Shoot_1>());
        } else if(Boss_5_ReceiveDame.currentHealth_Boss_5 <=0)
        { 
            Destroy(gameObject);
        }
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(7f);
        while (true)
        {
            GameObject bullet = Instantiate(Bullet_Pawn, Bullet_local_1.position, Bullet_local_1.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.right * -speedBullet;
            yield return new WaitForSeconds(timeWait);
        }

    }
}
