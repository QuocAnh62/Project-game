using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_1_Shoot : MonoBehaviour
{
    public GameObject Rocket;
    public GameObject Player;
    public Transform local;

    public float wait_ShootRocket;
    public float speed;
    float coolDown;
    

    private void Update()
    {
        Vector3 Dir = Player.transform.position - transform.position;
        if (Dir.y <= 1f && Dir.y >= -1f)
        {
            if(coolDown <= 0)
            {
                StartCoroutine(Shoot());
                coolDown = wait_ShootRocket;
            }            
        }
        if (Boss_1_ReceiveDame.currentHealth_Boss_1 <= 0 || Boss_ReceiveDame.currenthealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        coolDown -= Time.deltaTime;
    }


    IEnumerator Shoot()
    {                 
        GameObject bullet = Instantiate(Rocket, local.position, local.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.right * -speed, ForceMode2D.Impulse);
        yield break;       
    }
  
}
