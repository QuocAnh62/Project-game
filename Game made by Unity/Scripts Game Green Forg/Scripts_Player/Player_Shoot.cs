using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shoot : MonoBehaviour
{
    public GameObject BulletPerFab;
    public Transform FirePoint;

    void Update()
    {
        ShootBullet();
    }

    private void ShootBullet()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(BulletPerFab, FirePoint.position, FirePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = Vector3.right;
            Destroy(bullet,3f);
        }
    }
}
