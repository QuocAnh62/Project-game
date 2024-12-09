using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System.Net.Sockets;
public class CoolDownRocket : MonoBehaviour
{
    public Image imageCooldown;
    public TMP_Text textCooldown;

    private bool isCoolDown;
    private float coolDownTime = 8.0f;
    private float coolDownTimeStart = 0f;

    void Start()
    {
        textCooldown.gameObject.SetActive(false);
        imageCooldown.fillAmount = 0f;
    }

    void Update()
    {       
            //Debug.Log(Check);
            ApplyCoolDown();              
    }

    public void ApplyCoolDown()
    {
        coolDownTimeStart -= Time.deltaTime;

        if (coolDownTimeStart < 0.0f)
        {
            isCoolDown = false;
            textCooldown.gameObject.SetActive(false);
            imageCooldown.fillAmount = 0.0f;
        }
        else
        {
            textCooldown.text = Mathf.RoundToInt(coolDownTimeStart).ToString();
            imageCooldown.fillAmount = coolDownTimeStart / coolDownTime;
        }

    }
    public void Usespell()
    {
        isCoolDown = true;
        textCooldown.gameObject.SetActive(true);
        coolDownTimeStart = coolDownTime;
    }
 
}
