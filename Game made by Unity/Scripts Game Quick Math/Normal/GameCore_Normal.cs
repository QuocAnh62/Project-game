using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
//using static Unity.Burst.Intrinsics.Arm;
using Random = UnityEngine.Random;


public class GameCore_Normal : MonoBehaviour
{
    [SerializeField] private TMP_Text show_TextMath;
    [SerializeField] private GameObject show_TextInput;
    [SerializeField] private GameObject show_TextMathf;

    public static string string_Total;

    public static float time_TurnOffText = 0.5f;
    public static float time_TurnOff;

    public static int valueCount = 2;  
    public static int max_Value = 10;

    void Start()
    {
        time_TurnOff = 4.5f;
        StartCoroutine(waitToshowMath());
    }

    private IEnumerator waitToshowMath() // this function handle after 4 seconds will call first test math 
    {
        yield return new WaitForSeconds(4f);
        GenerateMathExpression();
    }


    private void Update()
    {
        if (time_TurnOff > 0) { time_TurnOff -= Time.deltaTime; }

        else { show_TextMathf.SetActive(false);}

    }

    public void CallExtrem() // thi function handle if submit is successful will call this function again show next test math
    {
        time_TurnOff = time_TurnOffText;
        GenerateMathExpression();
    }

    private void GenerateMathExpression()
    {
        List<double> values = new List<double>();

        for (int i = 0; i < valueCount; i++)
        {
            values.Add(Random.Range(5, max_Value));
        }

        List<string> operations = new List<string>();
        string[] availableOps = { "+", "-", "*", "/" };

        for (int i = 0; i < values.Count - 1; i++)
        {
            int randOpIndex = Random.Range(0, availableOps.Length);
            string newOp = availableOps[randOpIndex];

            operations.Add(newOp);           
        }
        
        showText_Math(values, operations);

        // Tính toán với thứ tự ưu tiên toán tử
        double result = EvaluateExpression(values, operations);
        string resultStr = result.ToString(CultureInfo.InvariantCulture);

        // Hiển thị kết quả
        if (Math.Abs(result * 1000 % 1) > 0 || notInfinity(result) || result == 0) { GenerateMathExpression(); }
        else
        {
            string_Total = resultStr.ToString();
            Debug.Log(resultStr);
            operations.Clear();
        }
    }

    /* --------------------------------------------------- */
    /* --------------- Part of Calculator --------------- */
    /* ------------------------------------------------- */
    protected double EvaluateExpression(List<double> values, List<string> operations)
    {
        List<double> tempValues = new List<double>(values);
        List<string> tempOps = new List<string>(operations);

        // Handle calculator time or slash * /
        for (int i = 0; i < tempOps.Count; i++)
        {
            if (tempOps[i] == "*" || tempOps[i] == "/")
            {
                tempValues[i] = tempOps[i] == "*" ? tempValues[i] * tempValues[i + 1] : tempValues[i] / tempValues[i + 1];

                tempValues.RemoveAt(i + 1);
                tempOps.RemoveAt(i);
                i--;
            }
        }


        // Xử lý cộng (+) và trừ (-)
        double total = tempValues[0];
        for (int i = 0; i < tempOps.Count; i++)
        {
            if (tempOps[i] == "+") { total += tempValues[i + 1]; } // Cộng giá trị tiếp theo nếu toán tử là "+"

            else if (tempOps[i] == "-") { total -= tempValues[i + 1]; } // Trừ giá trị tiếp theo nếu toán tử là "-"
        }


        tempValues.Clear();
        tempOps.Clear();
        return total;
    }



    private void showText_Math(List<double> values, List<string> operations)
    {
        show_TextMathf.SetActive(true);

        // Tạo biểu thức toán học từ danh sách values và operations
        string expression = values[0].ToString();
        for (int i = 0; i < operations.Count; i++)
        {
            expression +=  " " + operations[i] + " " + values[i + 1];
        }
        show_TextMath.text = expression;
    }


    protected bool notInfinity(double number)
    {
        if (double.IsInfinity(number))
        {
            Debug.LogWarning("Giá trị không hợp lệ: Infinity hoặc quá lớn!");
            return true;
        }
        return false;
    }


}
