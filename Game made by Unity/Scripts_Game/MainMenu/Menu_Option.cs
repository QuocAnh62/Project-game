using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menu_Option : MonoBehaviour
{
    Resolution[] resolutions;
    //public TMP_Dropdown TMP_dropdown;
    public TMP_Dropdown dropdown;

    private void Start()
    {
        resolutions = Screen.resolutions;
        ////dropdown.ClearOptions();

        //List<string> options = new List<string>();
        //foreach (Resolution res in resolutions)
        //{
        //    options.Add(res.ToString());
        //}
        //TMP_dropdown.AddOptions(options);

        List<string> options = new List<string>();
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
        }
        dropdown.AddOptions(options);
    }
    public void Volume(float volume)
    {
        Debug.Log(volume);
    }
}
