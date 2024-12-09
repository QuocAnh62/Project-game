using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Flollow : MonoBehaviour
{
    void Update()
    {      
        this.gameObject.transform.position = 
            Data_Player.Instance.trsForm_Player.position + new Vector3(-0.7f, 1.2f, 0);
    }

}
