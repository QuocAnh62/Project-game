using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Show_FPS : MonoBehaviour
{
    private float deltaTime = 0.0f;
    public TMP_Text fpsText;

    private void Start()
    {
        Application.targetFrameRate = 60;

        // Tắt vsync để sử dụng giới hạn FPS đặt bởi Application.targetFrameRate
        QualitySettings.vSyncCount = 0;
    }

    void Update()
    {
        // Tính toán thời gian trôi qua giữa các khung hình
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;

        // Tính toán FPS
        float fps = 1.0f / deltaTime;

        // Cập nhật văn bản hiển thị
        fpsText.text = $"FPS: {Mathf.Ceil(fps)}";
    }
}
