using Pathfinding.Examples;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class Enemy_Fly_Moving: MonoBehaviour
{
    public Transform StartPoint;
    public float speed;
    public bool chase = false;

    private float time = 0;
    private float reset = 0.6f;

    void Update()
    {
        if (Data_Player.Instance.trsForm_Player == null) return;
        if (chase ==true)
        {
            Chase();
            SoundEffect_Moving();
        }        
        else       
            ReturnStartPoint();                   
        Flip(); 
    }
  

    private void Chase()
    {
        
        UnityEngine.Vector3 distance = Data_Player.Instance.trsForm_Player.position - transform.position;
        if (distance.magnitude >= 1.2f)
        {
            UnityEngine.Vector3 targetPoint = Data_Player.Instance.trsForm_Player.position - distance.normalized * 1.2f;

            transform.position = 
                    UnityEngine.Vector2.MoveTowards(transform.position, Data_Player.Instance.trsForm_Player.position, speed * Time.deltaTime);
        }
       
    }

    private void ReturnStartPoint()
    {
        if(StartPoint == null) return;
        transform.position = UnityEngine.Vector2.MoveTowards(transform.position, StartPoint.transform.position, speed * Time.deltaTime);
    }

    private void Flip()
    {
        if (transform.position.x > Data_Player.Instance.trsForm_Player.position.x)
            transform.rotation = UnityEngine.Quaternion.Euler(0, 0, 0);
        else transform.rotation = UnityEngine.Quaternion.Euler(0,180,0);
    }

    private void SoundEffect_Moving()
    {
        time -= Time.deltaTime;
        if(time <= 0)
        {
            AudioManager.Instance.PlayEffect(AudioManager.Instance.Enemy_moving);
            time = reset;
        }
    }   
}
