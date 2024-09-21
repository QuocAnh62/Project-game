using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_Pink_Bullet : MonoBehaviour
{
    public GameObject Pink_Bullet;
    public Transform local;
    private Data data;

    private void Start()
    {
        data = GameObject.FindObjectOfType<Data>().GetComponent<Data>();
    }
    public void ShootPinkBullet()
    {
        GameObject pink_bullet = Instantiate(Pink_Bullet, local.position, local.rotation);
        Rigidbody2D rb = pink_bullet.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.right * data.speed_Pink_bullet;
    }
}
