using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart_Item : Moving_Up_Down
{
    private int plusHealth = 1;   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == Data_Player.Instance.boxcolli)
        {
            Data_Player.Instance.health_Player.Player_plusHealth(plusHealth);
            Destroy(this.gameObject);
        }
    }

}
