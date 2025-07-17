using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Plant_Shot : MonoBehaviour
{
    [SerializeField] private Transform transEnemy;
    private float timeShot = 0;
    public float coolDownTimeShot;
    private void Update()
    {
        timeShot -= Time.deltaTime;
        if (timeShot <= 0)
        {
            CalculShot();
            timeShot = coolDownTimeShot;         
        }
        
    }

    private void CalculShot() // Handle when to shot bullet
    {
        foreach (GameObject zombie in ManagerSpawnAndPool.instance.poolEnemy)
        {
            if (!zombie.activeInHierarchy) continue;

            float deltaY = Mathf.Abs(zombie.transform.position.y - transform.position.y); 
            float distanceX = zombie.transform.position.x - transform.position.x;
            //Debug.Log(deltaY);

            if (deltaY < 0.1f && distanceX > 0 && distanceX < 9) // cùng hàng
            {
                Shot();
            }
        }
    }

       

    private void Shot() // Handel Active bullet  in pool
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
    }

}
