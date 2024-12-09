using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Kill_Player : Health_HeartPlayer
{
    [Header("=================================")]
    [SerializeField] private float notDie_ByBoss = 3f;
    [SerializeField] private float coolDown_NotDie_ByBoss = 3f;
    protected void Time_MinusHealthByBoss()
    {
        notDie_ByBoss -= Time.deltaTime;
        if (notDie_ByBoss <= 0)
        {
            notDie_ByBoss = 0;
        }
    }

    public void BossTurtle_MinusHealthPlayer(int dameBoss)
    {
        if(notDie_ByBoss <= 0)
        {
            AudioManager.Instance.PlayEffect(AudioManager.Instance.Player_Hit);
            StartCoroutine(Anim_Hit());

            currenthealth_Player -= dameBoss;

            Active_Heart(Health = currenthealth_Player);
            StartCoroutine(Player_DieByTurtle(currenthealth_Player));

            notDie_ByBoss = coolDown_NotDie_ByBoss;
        }       
    }


    public void BossSkull_MinusHealthPlayer(int dameBoss)
    {
        if(notDie_ByBoss <= 0)
        {
            AudioManager.Instance.PlayEffect(AudioManager.Instance.Player_Hit);
            StartCoroutine(Anim_Hit());

            currenthealth_Player -= dameBoss;

            Active_Heart(Health = currenthealth_Player);
            StartCoroutine(Player_DieBySkull(currenthealth_Player));

            notDie_ByBoss = coolDown_NotDie_ByBoss;
        }
    }

    protected IEnumerator Anim_Hit()
    {
        Data_Player.Instance.anim_Player.SetBool("IsHit", true);

        yield return new WaitForSeconds(3f);

        Data_Player.Instance.anim_Player.SetBool("IsHit", false);

    }


    private IEnumerator Player_DieByTurtle(int health)
    {
        if (health <= 0)
        {          
            GameControll.Instance.Die();

            yield return new WaitForSeconds(0.2f); 
            
            Reset_Health();
            Active_Turtle.Instance.UnActive_Arena_Turtle();          
        }
    }


    private IEnumerator Player_DieBySkull(int health)
    {
        if (health <= 0)
        {
            GameControll.Instance.Die();

            yield return new WaitForSeconds(0.2f);

            Reset_Health();
            Active_Boss_Skull.Instance.UnActive_Arena_Skull();
        }
    }

    
}
