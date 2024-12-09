using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControll : MonoBehaviour
{
    Vector2 ChecPoint;
    public static GameControll Instance;  

    void Awake()
    {
        if(Instance == null) { Instance = this; }
    }
    void Start()
    {
        ChecPoint = transform.position;
    }

    public void UpdateCheckPoint(Vector2 pos)
    {
        ChecPoint = pos;
    }

    public void Die()
    {
        AudioManager.Instance.PlayEffect(AudioManager.Instance.Player_Die);
        StartCoroutine(ReSpawn(0.4f));
    }

    private IEnumerator ReSpawn(float wait)
    {
        TrueOrFalse_Weapon(false);

        Data_Player.Instance.artPlayer.enabled = false;
        Data_Player.Instance.rb.velocity = Vector2.zero;

        yield return new WaitForSeconds(wait);

        Data_Player.Instance.weapon_Gun.SetActive(true);

        Data_Player.Instance.anim_Player.SetBool("IsHit", false);
        Data_Player.Instance.artPlayer.enabled = true;

        transform.position = ChecPoint;
    }

    private void TrueOrFalse_Weapon(bool isActive)
    {
        Data_Player.Instance.weapon_Gun.SetActive(isActive);
        Data_Player.Instance.weapon_Melee.SetActive(isActive);
    }

}
