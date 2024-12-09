using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_4_ShootRocket : MonoBehaviour
{
    public GameObject Rocket;
    public GameObject Player;
    public Transform local;
    public GameObject MiniBoss;

    public float speedBullet;
    public float timeShoot;

    private void Start()
    {
        StartCoroutine(ShootRocket());
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


    IEnumerator ShootRocket()
    {
        yield return new WaitForSeconds(7f);
        while (true)
        {
            Vector3 Dir = Player.transform.position - transform.position;
            GameObject bullet = Instantiate(Rocket, local.position, local.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(Dir.x, Dir.y).normalized * speedBullet;
            yield return new WaitForSeconds(timeShoot);
        }

    }
}
