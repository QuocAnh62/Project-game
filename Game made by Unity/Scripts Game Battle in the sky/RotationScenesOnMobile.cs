using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScenesOnMobile : MonoBehaviour
{
    void Start()
    {
        // Đặt chế độ xoay màn hình thành landscape
        Screen.orientation = ScreenOrientation.AutoRotation;
    }
}
