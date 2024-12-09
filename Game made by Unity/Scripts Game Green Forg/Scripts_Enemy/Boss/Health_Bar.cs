using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Bar : MonoBehaviour
{
    [SerializeField] private Image full_Health;
    public void UpdatHealthBar(float currentHealth, float maxHealth)
    {
        full_Health.fillAmount = currentHealth / maxHealth;
    }


}
