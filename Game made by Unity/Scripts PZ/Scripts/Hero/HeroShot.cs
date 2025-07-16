using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroShot : MonoBehaviour
{    
    private bool isShot;

    private float timeShot = 0;
    public float coolDownTimeShot;

    private void Update()
    {
        Shot();
    }
    private void Shot()
    {
        if (isShot)
        {
            timeShot -= Time.deltaTime;
            if(timeShot <= 0)
            {
                foreach (GameObject bullet in ManagerSpawnAndPool.instance.poolBullet)
                {
                    if (!bullet.activeInHierarchy)
                    {
                        bullet.SetActive(true);
                        bullet.transform.position = this.transform.position;

                        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                        rb.velocity = Vector3.right * 7f;

                        break;
                    }
                }
                timeShot = coolDownTimeShot;
            }           
        }
        else return;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            isShot = true;
            //Debug.Log("Shoot");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            isShot = true;
            //Debug.Log("Shoot");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            isShot = false;
            //Debug.Log("Stop");
        }
    }
}
