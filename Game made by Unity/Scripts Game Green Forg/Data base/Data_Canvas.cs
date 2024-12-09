using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Data_Canvas : MonoBehaviour
{
    public static Data_Canvas Instance;

    [Header("------ Text -----")]
    public GameObject popUpDamage;
    public TMP_Text popText;
    
    void Start()
    {
        if (Instance == null) Instance = this;
    }

   
}
