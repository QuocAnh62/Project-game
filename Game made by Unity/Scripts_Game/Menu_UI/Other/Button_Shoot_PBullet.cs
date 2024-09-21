using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Shoot_PBullet : MonoBehaviour
{
    private Shoot_Pink_Bullet pink_bullet;
    private void Start()
    {
        pink_bullet = GameObject.FindObjectOfType<Shoot_Bullet_Rocket>().GetComponent<Shoot_Pink_Bullet>();
    }

    public void Shoot_P_Bullet()
    {
        pink_bullet.ShootPinkBullet();
    }
}
