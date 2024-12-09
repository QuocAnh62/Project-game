using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Switch_Weapon : MonoBehaviour
{
    [SerializeField] protected GameObject ammo_Eagle;
    [SerializeField] protected GameObject ammo_Ak_47;
    public GameObject Ak_47;
    public GameObject Eagle;
    public GameObject Melee;

    void Update()
    {
        Switch();
    }

    private void Switch()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))  // Switch to Ak-47
        {
            Check_ActiveAk();          
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))  // Switch to pistol 
        {
            Eagle.SetActive(true);
            ammo_Eagle.SetActive(true);

            Melee.SetActive(false);

            Check_NotActiveAk();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))  // Switch to melee
        {
            Melee.SetActive(true);

            Eagle.SetActive(false);
            ammo_Eagle.SetActive(false);

            Check_NotActiveAk();
        }
    }
    
    public void Add_Ak47(GameObject ak47)
    {
        Ak_47 = ak47;
    }

    private void Check_ActiveAk() // Check Active Ak-47 not Null will Active Ak-47 true
    {
        if (Ak_47 != null)
        {
            Ak_47.SetActive(true);
            ammo_Ak_47.SetActive(true);

            Melee.SetActive(false);

            Eagle.SetActive(false);
            ammo_Eagle.SetActive(false);
        }
        else return;
    } 
    
    private void Check_NotActiveAk() // Check Active Ak-47 not Null will Active Ak-47 false
    {
        if (Ak_47 != null)
        {
            Ak_47.SetActive(false);
            ammo_Ak_47.SetActive(false);
        }
        else return;
    } 
}
