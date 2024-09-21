using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButton : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.SetInt("Coint_3th", 9999);
        Destroy(GetComponent<TestButton>());
    }
}
