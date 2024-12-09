using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plus_Ammo_Pistol : Moving_Up_Down
{
    private int ammo = 7;  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == Data_Player.Instance.boxcolli)
        {
            if (Data_Player.Instance == null) return;
            if (UI_Ammo.Instance == null) return;
            else Data_Player.Instance.deset_eagle.Add_Ammo(ammo);
            Destroy(this.gameObject);
        }
    }
}
