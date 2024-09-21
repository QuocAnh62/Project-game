using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;

public class Boss_2_ShootBullet : MonoBehaviour
{
    public GameObject Bullet;
    public Transform local;
    public float speed_bullet;
    public float wait;
    void Start()
    {
        StartCoroutine(Shoot());
    }

    private void Update()
    {
        if (Boss_2_ReceiveDame.currentHealth_Boss_2 <= 0 || Boss_ReceiveDame.currenthealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(6.5f);
        while (true)
        {
            GameObject bullet = Instantiate(Bullet, local.position, local.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(Vector2.right * - speed_bullet,ForceMode2D.Impulse);
            yield return new WaitForSeconds(wait);
        }
    }
}
