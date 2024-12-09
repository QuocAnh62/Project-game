using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_1_ShootFollowPlayer : MonoBehaviour
{
    public GameObject Bullet;
    public Transform local;

    public float speed;
    public float wait;

    private GameObject Player;
    
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(ShootFollowPlayer());
    }

    private void FixedUpdate()
    {
        if (Boss_1_ReceiveDame.currentHealth_Boss_1 <= 0 || Boss_ReceiveDame.currenthealth <= 0)
        {
            Destroy(gameObject);
        }
        Vector3 Dir = Player.transform.position - transform.position;
        float angle = Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + 180);
    }

    IEnumerator ShootFollowPlayer()
    {
        yield return new WaitForSeconds(6.5f);        
        while (true)
        {           
            Vector3 Dir = Player.transform.position - transform.position;
                       
            GameObject bullet = Instantiate(Bullet, local.position, local.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            rb.velocity = new Vector2(Dir.x, Dir.y).normalized * speed;

            yield return new WaitForSeconds(wait);
        }                
    }
    
}
