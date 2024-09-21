using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn_Shoot : MonoBehaviour
{
    public GameObject Bullet_Pawn;
    public Transform Bullet_local;
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
            Destroy(GetComponent<Pawn_Shoot>());
        } else if(Boss_5_ReceiveDame.currentHealth_Boss_5 <=0)
        {
            Destroy(gameObject);
        }
    }


    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(6.5f);
        while (true)
        {
            GameObject bullet = Instantiate(Bullet_Pawn, Bullet_local.position, Bullet_local.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.right * -speedBullet;
            yield return new WaitForSeconds(timeWait);
        }

    }
}
