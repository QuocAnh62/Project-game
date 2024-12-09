using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartSystem : MonoBehaviour
{
    public static int Health = 4;

    public Image[] heart;
    public Sprite fullheart;

    
    private void Update()
    {
        for (int i = 0; i < heart.Length; i++)
        {
           
            if (i < Health)
            {
                heart[i].enabled = true;
            }
            else
            {
                heart[i].enabled = false;
            }
         
        }
    }
}
