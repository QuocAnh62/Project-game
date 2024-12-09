using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Follow_PLayer : MonoBehaviour
{
    private float time = 0;
    private float reset = 0.6f;

    private void Update()
    {
        
        FollowPlayer();
        Flip();
    }
    public void FollowPlayer()
    {
        Vector3 distance = Data_Player.Instance.trsForm_Player.position - transform.position; // calcurlate pos from player to enenmy

        if (distance.magnitude >= 0.5f)
        {            
            Vector3 targetPoint = Data_Player.Instance.trsForm_Player.position - distance.normalized * 0.7f;

            gameObject.transform.position =
              Vector3.MoveTowards(gameObject.transform.position, targetPoint, 5 * Time.deltaTime);
        }

        if(distance.magnitude <= 15f) SoundEffect_Moving();
    }

    private void Flip()
    {
        if (transform.position.x > Data_Player.Instance.trsForm_Player.position.x)
            transform.rotation = UnityEngine.Quaternion.Euler(0, 0, 0);
        else transform.rotation = UnityEngine.Quaternion.Euler(0, 180, 0);
    }

    private void SoundEffect_Moving()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            AudioManager.Instance.PlayEffect(AudioManager.Instance.Enemy_moving);
            time = reset;
        }
    }
}
