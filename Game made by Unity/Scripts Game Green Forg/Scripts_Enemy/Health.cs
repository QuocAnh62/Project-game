using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{    
    protected int health_enemy;
    protected int max_Health;
    protected virtual void Start()
    {
        max_Health = health_enemy;       
    }

    public virtual void Enemy_GetDame(int dame)
    {
        AudioManager.Instance.PlayEffect(AudioManager.Instance.Bonk);// PLaye Effect Bonk

        health_enemy -= dame;
        Text_popUp(15);

        if (health_enemy <= 0)
        {
             Destroy(this.gameObject);
        }
    }

    public virtual void Enemy_GetDameBullet(int dame)
    {
        AudioManager.Instance.PlayEffect(AudioManager.Instance.Bonk);// PLaye Effect Bonk

        health_enemy -= dame;
        Text_popUp(10);
        
        if (health_enemy <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    protected virtual void Text_popUp(int dame)
    {       
        Data_Canvas.Instance.popText.text = dame.ToString();
        GameObject text =
         Instantiate(Data_Canvas.Instance.popUpDamage, transform.position + new Vector3(0, 1.5f, 0), Quaternion.identity);
        Destroy(text, .2f);       
    }


    protected virtual void DoAnima()
    {
        Debug.Log("Active Anima");
    }

}
