using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skull_CastSkill_2 : Skill_Boss
{

    [SerializeField] private float time;
    [SerializeField] private float restart;

    protected void Update()
    {
        calculate();
        if (time <= 0)
        {
            random_Skill();
            time = restart;
        }
        time -= Time.deltaTime;
    }

    private void random_Skill()
    {
        int dex = Random.Range(0, 3);
        // Debug.Log("randon " + dex);
        switch (dex)
        {

            case 0:
                three_fireBall();
                break;

            case 1:
                OnTopPlayer();
                
                break;

            case 2:                
                ball_circle();
                break;

        }
    }

    private void OnTopPlayer()
    {
        transform.parent.parent.position = Data_Player.Instance.trsForm_Player.position + new Vector3(0, 12f, 0);
        StartCoroutine(ActiveSkill_oneShoot());
    }

    private IEnumerator ActiveSkill_oneShoot()
    {
        yield return new WaitForSeconds(0.2f);
        oneShoot_3Ball();
    }
   
}
