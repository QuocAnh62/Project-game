using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_5_ShootBullet : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject Player;
    public Transform local;

    public float speedBullet;
    public float timeShoot;
    public float timeWaitShoot;

    private void Start()
    {
        StartCoroutine(Shootbullet());
    }

    private void Update()
    {
        Vector3 Dir = Player.transform.position - transform.position;
        float rot = Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 180);
    }

    private void FixedUpdate()
    {
        if (Boss_5_ReceiveDame.currentHealth_Boss_5 <= 0 || Boss_ReceiveDame.currenthealth <= 0)
        {
            Destroy(GetComponent<Boss_5_ShootBullet>());
        }
    }


    IEnumerator Shootbullet()
    {
        yield return new WaitForSeconds(timeWaitShoot);
        while (true)
        {
            Vector3 Dir = Player.transform.position - transform.position;
            GameObject bullet = Instantiate(Bullet, local.position, local.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(Dir.x, Dir.y).normalized * speedBullet;
            yield return new WaitForSeconds(timeShoot);
        }

    }
}
