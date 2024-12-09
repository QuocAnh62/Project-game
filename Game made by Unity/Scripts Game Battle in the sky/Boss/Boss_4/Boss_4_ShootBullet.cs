using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_4_ShootBullet : MonoBehaviour
{   
    public GameObject Bullet;
    public GameObject Player;
    public Transform local;
    public GameObject MiniBoss;

    public float speedBullet;
    public float timeShoot;

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
        if (Boss_4_ReceiveDame.currentHealth_Boss_4 <= 0 || Boss_ReceiveDame.currenthealth <= 0)
        {
            Destroy(MiniBoss);
        }
    }


    IEnumerator Shootbullet()
    {
        yield return new WaitForSeconds(6.5f);
        while(true)
        {
            Vector3 Dir = Player.transform.position - transform.position;
            GameObject bullet = Instantiate(Bullet, local.position, local.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(Dir.x, Dir.y).normalized * speedBullet;
            yield return new WaitForSeconds(timeShoot);
        }
        
    }
}
