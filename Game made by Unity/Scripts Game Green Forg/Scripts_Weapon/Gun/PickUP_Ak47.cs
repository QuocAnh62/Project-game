using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUP_Ak47 :Moving_Up_Down
{
    [SerializeField] private GameObject Ak47;
    [SerializeField] private GameObject UIAK47;
    [SerializeField] private Switch_Weapon addAk;
    [SerializeField] private List<GameObject> inActive;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Ak47.SetActive(true);
            UIAK47.SetActive(true);
           
            inActive_PistolMelee();

            addAk.Add_Ak47(Ak47);
            Destroy(this.gameObject);
        }
    }

    private void inActive_PistolMelee() // not Active weapon pistol or melee
    {
        foreach (GameObject weapon in inActive) 
        {
            weapon.SetActive(false);
        }
    }
}
