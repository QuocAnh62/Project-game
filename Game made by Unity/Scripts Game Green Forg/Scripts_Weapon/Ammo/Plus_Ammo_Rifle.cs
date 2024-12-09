using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plus_Ammo_Rifle : Moving_Up_Down
{
    private int ammo = 15;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == Data_Player.Instance.boxcolli)
        {
            if (Data_Player.Instance.ak47 == null || UI_Ammo.Instance == null) return;

            else
            { 
                Data_Player.Instance.ak47.Add_Ammo(ammo);
                Destroy(this.gameObject);
            }            
            
        }
    }
}
