using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Boss_Skull : MonoBehaviour
{
    public static Manager_Boss_Skull Instance;

    public State_Skull state_Skull;
    private void Awake()
    {
        if(Instance == null) Instance = this;
    }
}
