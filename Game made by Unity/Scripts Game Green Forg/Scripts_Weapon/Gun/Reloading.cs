using System.Collections;
using UnityEngine;

public class Reloading : MonoBehaviour
{
    protected float time_ReloadingPistol = 1.2f;
    protected float time_ReloadingRifle = 1.8f;
    protected float TimeBtwShoot = 0f;

    protected int current_AmmoInGun;
    protected int ammo_Reloading;
    protected int max_ammo;
    

    protected virtual void Start()
    {
        // set ammo count
    }

    protected virtual void Loading_AmmoPistol(int ammo)
    {
        if (Input.GetKeyDown(KeyCode.R) && current_AmmoInGun <= ammo_Reloading - 1 && max_ammo > 0)
        {
            TimeBtwShoot = time_ReloadingPistol;
            AudioManager.Instance.PlayEffect(AudioManager.Instance.Reload_Pistol);

            StartCoroutine(UpdateUI_AmmoPistol(ammo));
        }
    }


    protected virtual void Loading_AmmoRifle(int ammo)
    {
        if (Input.GetKeyDown(KeyCode.R) && current_AmmoInGun <= ammo_Reloading - 1 && max_ammo > 0)
        {
            TimeBtwShoot = time_ReloadingRifle;
            AudioManager.Instance.PlayEffect(AudioManager.Instance.Reload_Ak47);

            StartCoroutine(UpdateUI_AmmoRifle(ammo));
        }
    }



    private IEnumerator UpdateUI_AmmoPistol(int ammo)
    {
        int maxAmmoIngun = max_ammo;// current max ammo in gun
        int needReloading = ammo_Reloading - ammo; // number ammo need to reload = ammo reload(7) - current ammo in gun

        if (needReloading <= maxAmmoIngun) // if ammo need to reload less current max ammo in gun 
        {
            ammo += needReloading; // plus number ammo in gun for to shoot
            max_ammo -= needReloading; // number max ammo after max ammo in gun minus ammo need to reload
        }
        else
        {
            ammo += maxAmmoIngun; // plus number ammo 
            max_ammo -= maxAmmoIngun; //  max ammo in gun =0
        }


        UI_Ammo.Instance.ShowCurrentAmmoPistol(this.current_AmmoInGun, this.max_ammo);
        this.current_AmmoInGun = ammo; // Set ammo in gun = ammo after plus

        yield return new WaitForSeconds(time_ReloadingPistol);

        UI_Ammo.Instance.ShowCurrentAmmoPistol(this.current_AmmoInGun, this.max_ammo);
    }

    private IEnumerator UpdateUI_AmmoRifle(int ammo)
    {
        int maxAmmoIngun = max_ammo;// current max ammo in gun
        int needReloading = ammo_Reloading - ammo; // number ammo need to reload = ammo reload(7) - current ammo in gun

        if (needReloading <= maxAmmoIngun) // if ammo need to reload less current max ammo in gun 
        {
            ammo += needReloading; // plus number ammo in gun for to shoot
            max_ammo -= needReloading; // number max ammo after max ammo in gun minus ammo need to reload
        }
        else
        {
            ammo += maxAmmoIngun; // plus number ammo 
            max_ammo -= maxAmmoIngun; //  max ammo in gun =0
        }

        UI_Ammo.Instance.ShowCurrentAmmoRifle(this.current_AmmoInGun, this.max_ammo);
        this.current_AmmoInGun = ammo; // Set ammo in gun = ammo after plus

        yield return new WaitForSeconds(time_ReloadingRifle);

        UI_Ammo.Instance.ShowCurrentAmmoRifle(this.current_AmmoInGun, this.max_ammo);
    }


}
