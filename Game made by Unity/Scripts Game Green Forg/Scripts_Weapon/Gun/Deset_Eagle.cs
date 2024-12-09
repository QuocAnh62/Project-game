using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;


public class Deset_Eagle : Reloading
{
    [SerializeField] private Transform holderBullet;
    [SerializeField] private GameObject BulletPerfab_Eagle;
    [SerializeField] private Transform ShootingPoint;
    public float SpeedBullet = 35f;
    public float RestartTimeShoot = 0.5f;
    public bool IsShoot = true;

    protected override void Start()
    {
        current_AmmoInGun = 7;
        ammo_Reloading = 7;
        max_ammo = 42;
       
        UI_Ammo.Instance.ShowCurrentAmmoPistol(current_AmmoInGun, max_ammo);
    }

    protected void OnEnable()
    {
        if (UI_Ammo.Instance != null)        
            UI_Ammo.Instance.ShowCurrentAmmoPistol(current_AmmoInGun, max_ammo);
        
        else return;              
    }

    protected void Update()
    {       
        Calcul_Dir_Fire();
        Manager_ShootBullet();       
    }   

    private void Calcul_Dir_Fire()
    {
        Vector3 CamPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = CamPos - transform.position;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = rotation;

        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
        {
            transform.localScale = new Vector3(1, -1, 0);
        }
        else transform.localScale = new Vector3(1, 1, 0);

    }


    private void Manager_ShootBullet()
    {
        TimeBtwShoot -= Time.deltaTime;     
        Loading_AmmoPistol(current_AmmoInGun);
        ShootBullet();
    }


    private void ShootBullet()
    {
        if (Input.GetMouseButton(0) && TimeBtwShoot <= 0 && current_AmmoInGun >= 1 && IsShoot)
        {
            SpawnBullet();
            AudioManager.Instance.PlayEffect(AudioManager.Instance.Pistol);

            current_AmmoInGun -= 1;
            UI_Ammo.Instance.ShowCurrentAmmoPistol(current_AmmoInGun, max_ammo);

            TimeBtwShoot = RestartTimeShoot;
        }
    }


    private void SpawnBullet()
    {
        GameObject bullet = Instantiate(BulletPerfab_Eagle, ShootingPoint.position, transform.rotation);
        bullet.transform.parent = holderBullet;

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * SpeedBullet, ForceMode2D.Impulse);       
        Destroy(bullet, 1f);
    }


    public void Add_Ammo(int ammo)
    {
        max_ammo += ammo;
        AudioManager.Instance.PlayEffect(AudioManager.Instance.Ammo_PickUp);
        UI_Ammo.Instance.ShowCurrentAmmoPistol(current_AmmoInGun, max_ammo);
    }

    protected override void Loading_AmmoPistol(int ammo)
    {
        base.Loading_AmmoPistol(ammo);
    }

}
