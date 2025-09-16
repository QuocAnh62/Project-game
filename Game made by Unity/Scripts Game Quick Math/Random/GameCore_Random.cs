using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using Random = UnityEngine.Random;
using Unity.VisualScripting;
using System.Reflection;
using System.Globalization;
using System.Diagnostics;

public class GameCore_Random : SystemCalculator
{
    [SerializeField] private TMP_Text show_TextMath;
    [SerializeField] private GameObject show_TextMathf;
    [SerializeField] private GameObject show_TextInput;

    public static string string_Total;

    public static float time_TurnOffText = 2f;
    public static float time_TurnOff;

    public static int min_Value = 1;
    public static int max_Value = 10;
    public static int max_ValuePow = 3;

    public static int min_ValueShowText;
    public static int max_ValueShowText;


    void Start()
    {
        time_TurnOff = 6;
        min_ValueShowText = 2;
        max_ValueShowText = 4;
        StartCoroutine(waitToshowMath());
    }

    private IEnumerator waitToshowMath() // this function handle after 4 seconds will call first test math 
    {
        yield return new WaitForSeconds(4f);
        GenerateMathExpression();
    }


    private void Update()
    {       
        if(time_TurnOff >=0)
        {
            time_TurnOff -= Time.deltaTime;
        }
        if (time_TurnOff <= 0) { show_TextMathf.SetActive(false); }
    }
   

    public void CallExtrem()
    {
        time_TurnOff = time_TurnOffText;
        GenerateMathExpression();
    }

    /* --------------------------------------------------- */
    /* --------------- Part of Show Test --------------- */
    /* ------------------------------------------------- */

    private void GenerateMathExpression()
    {
        // Danh sách số
        int valueCount = Random.Range(min_ValueShowText, max_ValueShowText);

        List<double> values = new List<double>();
        for (int i = 0; i < valueCount; i++)
        {
            values.Add(Random.Range(5, max_Value));
        }


        List<string> operations = new List<string>();
        string[] availableOps = { "+", "-", "*", "/", "√", "^" };
        int[] opCount = new int[availableOps.Length]; // Mảng đếm số lần xuất hiện của mỗi toán tử
        string lastOp = "";

        for (int i = 0; i < values.Count - 1; i++)
        {
            int randOpIndex = Random.Range(0, availableOps.Length);
            string newOp = availableOps[randOpIndex];

            // Kiểm tra điều kiện trước khi thêm vào danh sách
            while (newOp == lastOp || opCount[randOpIndex] >= 3)
            {
                randOpIndex = Random.Range(0, availableOps.Length);
                newOp = availableOps[randOpIndex];
            }

            // Nếu toán tử là "^", đảm bảo số sau nó từ 4 đến 6
            if (newOp == "^")
            {
                values[i + 1] = Random.Range(2, max_ValuePow);
            }

            operations.Add(newOp);
            lastOp = newOp;
            opCount[randOpIndex]++; // Cập nhật số lần xuất hiện của toán tử
        }


        checkSize(valueCount);
        showText_Math(values, operations);


        double result = EvaluateExpression(values, operations);   // Tính toán với thứ tự ưu tiên toán tử
        string resultStr = result.ToString(CultureInfo.InvariantCulture);


        // Hiển thị kết quả
        if (Math.Abs(result * 1000 % 1) > 0 || notInfinity(result)) { GenerateMathExpression(); }
        else
        {
            string_Total = resultStr.ToString();
            UnityEngine.Debug.Log(resultStr);          
            operations.Clear();
        }
    }

    private void showText_Math(List<double> values, List<string> operations) // Handle show test math
    {
        show_TextMathf.SetActive(true);

        // Tạo biểu thức toán học từ danh sách values và operations
        string expression = values[0].ToString();
        
        for (int i = 0; i < operations.Count; i++)
        {
            expression += " " + operations[i] + " " + values[i + 1];
        }

        show_TextMath.text = expression; // Hiển thị biểu thức toán học

    }

    private void checkSize(int valuecount) // Handle fontSize
    {
        if (Manager_ButtonRandom.score >= 30)
        {
            switch (valuecount)
            {
                case 3:
                    show_TextMath.fontSize = 33;
                    break;
                case 4:
                    show_TextMath.fontSize = 30;
                    break;
                case 5:
                    show_TextMath.fontSize = 27;
                    break;
            }
        }

        if (Manager_ButtonRandom.score >= 150)
        {
            switch (valuecount)
            {
                case 3:
                    show_TextMath.fontSize = 32;
                    break;
                case 4:
                    show_TextMath.fontSize = 27;
                    break;
                case 5:
                    if (Manager_ButtonRandom.score >= 230) { show_TextMath.fontSize = 22; }

                    else
                        show_TextMath.fontSize = 24;
                    break;
                case 6:
                    if (Manager_ButtonRandom.score >= 300) { show_TextMath.fontSize = 18; }

                    else
                        show_TextMath.fontSize = 22;
                    break;
            }
        }
    }
}
