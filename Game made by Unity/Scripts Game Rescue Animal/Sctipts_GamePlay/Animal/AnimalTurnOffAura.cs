using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalTurnOffAura : MonoBehaviour
{
    public GameObject aura; // Đặt object Aura trong Inspector

    public void PickUp()
    {
        if (aura != null)
        {
            aura.SetActive(false); // Tắt object Aura
        }     
    }
}
