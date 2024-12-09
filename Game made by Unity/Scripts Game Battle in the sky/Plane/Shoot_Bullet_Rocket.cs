using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Shoot_Bullet_Rocket : MonoBehaviour
{
    public Transform target;
    public GameObject Rocket;
    public GameObject Bullet;
   
    Animator anim_Player;
    private Data data;
    private CountTime time;  

    private void Start()
    {
        
        anim_Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        data = GameObject.FindAnyObjectByType<Data>().GetComponent<Data>();
        time = GameObject.FindAnyObjectByType<CountTime>().GetComponent<CountTime>();
    }

    public void shoot() // Shoot White_Bullet
    {
        GameObject bullet = Instantiate(Bullet, target.position, target.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        StartCoroutine(AnimShootBullet());
        rb.AddForce(target.right * data.speed_bullet, ForceMode2D.Impulse);       
    }

    public void shootRocket() // Shoot Rocket
    {
        GameObject rocket = Instantiate(Rocket, target.position, target.rotation);
        Rigidbody2D rb = rocket.GetComponent<Rigidbody2D>();
        rb.AddForce(target.right * data.speed_rocket, ForceMode2D.Impulse);
    }

    IEnumerator AnimShootBullet() // Handle animation when Player_Shoot
    {
        anim_Player.SetBool("Shoot", true);
        yield return new WaitForSeconds(0.1f);
        anim_Player.SetBool("Shoot", false);
    }


}
