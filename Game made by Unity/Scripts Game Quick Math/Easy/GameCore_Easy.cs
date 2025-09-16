using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;


public class GameCore_Easy : MonoBehaviour
{
    [SerializeField] private TMP_Text show_TextMath;
    [SerializeField] private GameObject textMath_Obj;
    [SerializeField] private GameObject show_TextInput;

    public static string string_Total;

    //private string oprattion = " " ;

    /* ------------- Rule -------------*/

    public static float time_TurnOffText = 0.5f; // 0.5f
    public static float time_TurnOff;

    public static int max_Value; //10

    public static int valueCount;
    void Start()
    {
        time_TurnOff = 4.5f;
        max_Value = 9;
        valueCount = 2;
        StartCoroutine(waitToshowMath());   
    }

    private IEnumerator waitToshowMath()
    {
        yield return new WaitForSeconds(4f);
        GenerateMathExpression();
    }

    private void Update()
    {
        if (time_TurnOff > 0) { time_TurnOff -= Time.deltaTime; }

        else { textMath_Obj.SetActive(false); }
    }

    public void CallExtrem()
    {
        time_TurnOff = time_TurnOffText;
        GenerateMathExpression();
    }


    private void GenerateMathExpression()
    {
        List<double> values = new List<double>();

        for (int i = 0; i < valueCount; i++)
        {
            values.Add(Random.Range(1, max_Value));
        }

        List<string> operations = new List<string>();
        string[] availableOps = { "+", "-"};

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
        if (result < 0) { GenerateMathExpression(); }
        else
        {
            string_Total = resultStr.ToString();
            Debug.Log(resultStr);
            operations.Clear();
        }
    }

    protected double EvaluateExpression(List<double> values, List<string> operations)
    {
        List<double> tempValues = new List<double>(values);
        List<string> tempOps = new List<string>(operations);

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
        textMath_Obj.SetActive(true);

        // Tạo biểu thức toán học từ danh sách values và operations
        string expression = values[0].ToString();
        for (int i = 0; i < operations.Count; i++)
        {
            expression += " " + operations[i] + " " + values[i + 1];
        }
        show_TextMath.text = expression;
    }

   


}
