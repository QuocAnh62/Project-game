using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_3_ShootRocket : MonoBehaviour
{
    public GameObject Bullet;
    public Transform local;

    public float speed;
    public float waitShootRocket;

    void Start()
    {
        StartCoroutine(ShootRocket());
    }

    private void FixedUpdate()
    {
        if (Boss_3_ReceiveDame.currentHealth_Boss_3 <= 0 || Boss_ReceiveDame.currenthealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator ShootRocket()
    {
        yield return new WaitForSeconds(6.5f);
        while (true)
        {
            GameObject bullet = Instantiate(Bullet, local.position, local.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            rb.velocity = Vector2.right * -speed;

            yield return new WaitForSeconds(waitShootRocket);
        }
        
    }
}
