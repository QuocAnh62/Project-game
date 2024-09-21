using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Bullet : MonoBehaviour
{
    public GameObject Button_Pink_Bullet;
    float T_SwitchBullet = 5f;
    bool Check;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PBullet"))
        {
            Check = true;
            Switch();
        }
    }


    public void Switch()
    {
        if(Check == true)
        {
            Button_Pink_Bullet.SetActive(true);
            T_SwitchBullet = 5f;         
        }
    }

    private void FixedUpdate()
    {
        if (T_SwitchBullet <= 0)
        {
            Button_Pink_Bullet.SetActive(false);
            Check = false;
        }
        T_SwitchBullet -= Time.deltaTime;
        
    }
}
