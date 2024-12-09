using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ak47 : Reloading
{
    [SerializeField] private Transform holderBullet;
    [SerializeField] private GameObject BulletPerfab_Eagle;
    [SerializeField] private Transform ShootingPoint;
    public float SpeedBullet = 40f;
    public float RestartTimeShoot = 0.2f;


    protected override void Start()
    {
        current_AmmoInGun = 30;
        ammo_Reloading = 30;
        max_ammo = 60;

        UI_Ammo.Instance.ShowCurrentAmmoRifle(current_AmmoInGun, max_ammo);
    }

    private void OnEnable()
    {
        if (UI_Ammo.Instance != null)
            UI_Ammo.Instance.ShowCurrentAmmoRifle(current_AmmoInGun, max_ammo);

        else return;
    }

    protected void Update()
    {
        Calcul_Dir_Fire();
        Manager_ShootBullet();
        ShootBullet();
    }


    private void Calcul_Dir_Fire()
    {
        Vector3 CamPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = CamPos - transform.position;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = rotation;

        if(transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
        {
            transform.localScale = new Vector3(1, -1, 0);
        }else transform.localScale = new Vector3(1, 1, 0);

    }


    private void Manager_ShootBullet()
    {
        TimeBtwShoot -= Time.deltaTime;

        Loading_AmmoRifle(current_AmmoInGun);
        ShootBullet();

    }

    private void ShootBullet()
    {
        if (Input.GetMouseButton(0) && TimeBtwShoot <= 0 && current_AmmoInGun >= 1)
        {
            SpawnBullet();
            AudioManager.Instance.PlayEffect(AudioManager.Instance.Ak47); // play sound effect Chicken

            current_AmmoInGun -= 1;
            UI_Ammo.Instance.ShowCurrentAmmoRifle(current_AmmoInGun, max_ammo);

            TimeBtwShoot = RestartTimeShoot;
        }
    }

    private void SpawnBullet()
    {
        GameObject bullet = Instantiate(BulletPerfab_Eagle, ShootingPoint.position, ShootingPoint.rotation);
        bullet.transform.parent = holderBullet;

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * SpeedBullet, ForceMode2D.Impulse);
        Destroy(bullet, 1f);
    }


    public void Add_Ammo(int ammo)
    {
        max_ammo += ammo;
        AudioManager.Instance.PlayEffect(AudioManager.Instance.Ammo_PickUp);
        UI_Ammo.Instance.ShowCurrentAmmoRifle(current_AmmoInGun, max_ammo);
    }


    protected override void Loading_AmmoRifle(int ammo)
    {
        base.Loading_AmmoRifle(ammo);
    }   

}

