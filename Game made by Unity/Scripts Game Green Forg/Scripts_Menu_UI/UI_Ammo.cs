using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Ammo : MonoBehaviour
{
    public static UI_Ammo Instance;
    [SerializeField] private TMP_Text num_AmmoPistol;
    [SerializeField] private TMP_Text num_AmmoRifle;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Debug.LogError("UI Ammo Pistol NULL");
    }

    public void ShowCurrentAmmoPistol(int currentAmmo, int maxAmmo)
    {
        num_AmmoPistol.text = currentAmmo + "/" + maxAmmo ;
    }

    public void ShowCurrentAmmoRifle(int currentAmmo, int maxAmmo)
    {
        num_AmmoRifle.text = currentAmmo + "/" + maxAmmo;
    }
}
