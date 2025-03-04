using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Input : MonoBehaviour
{
    public static Manager_Input Instance;

    public Transform transformPlayer;
    public Transform finish_Line1;

    private void Awake()
    {
        if(Instance == null) Instance = this;
    }
}
