using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SystemCalculator : MonoBehaviour
{
    /* --------------------------------------------------- */
    /* --------------- Part of Calculator --------------- */
    /* ------------------------------------------------- */

    protected double EvaluateExpression(List<double> values, List<string> operations)
    {
        List<double> tempValues = new List<double>(values);
        List<string> tempOps = new List<string>(operations);

        // Handle calculator Sqrt  √
        for (int i = 0; i < tempOps.Count; i++)
        {
            if (tempOps[i] == "√" && i + 1 < tempValues.Count)
            {
                tempValues[i + 1] = Math.Sqrt(tempValues[i + 1]);
                //Debug.Log($"sqrt: √ {tempValues[i + 1]} = {tempValues[i + 1]} ");
                tempOps[i] = "*";
                i--;
            }
        }


        // Handle calculator Pow  ^
        for (int i = 0; i < tempOps.Count; i++)
        {
            if (tempOps[i] == "^" && i + 1 < tempValues.Count) // Kiểm tra toán tử lũy thừa
            {
                //Debug.Log($"pow: {tempValues[i]} ^ {tempValues[i + 1]} = {Math.Pow(tempValues[i], tempValues[i + 1])}");
                tempValues[i] = Math.Pow(tempValues[i], tempValues[i + 1]); // Tính lũy thừa              
                tempValues.RemoveAt(i + 1); // Xóa số đã dùng trong phép toán
                tempOps.RemoveAt(i); // Xóa toán tử sau khi xử lý
                i--; // Giảm chỉ mục để tránh lỗi
            }
        }


        // Handle calculator time or slash * /
        for (int i = 0; i < tempOps.Count; i++)
        {
            if (tempOps[i] == "*" || tempOps[i] == "/")
            {
                double asd = tempValues[i];

                tempValues[i] = tempOps[i] == "*" ? tempValues[i] * tempValues[i + 1] : tempValues[i] / tempValues[i + 1];

                //Debug.Log($"Phép toán: {asd} {tempOps[i]} {tempValues[i + 1]} = {tempValues[i]}");

                tempValues.RemoveAt(i + 1);
                tempOps.RemoveAt(i);
                i--;
            }
        }


        // Xử lý cộng (+) và trừ (-)
        double total = tempValues[0];
        for (int i = 0; i < tempOps.Count; i++)
        {
            if (tempOps[i] == "+")
            {
                total += tempValues[i + 1]; // Cộng giá trị tiếp theo nếu toán tử là "+"
            }
            else if (tempOps[i] == "-")
            {
                total -= tempValues[i + 1]; // Trừ giá trị tiếp theo nếu toán tử là "-"
            }
        }


        tempValues.Clear();
        tempOps.Clear();
        return total;
    }



    /* --------------------------------------------------- */
    /* --------------- Part of Condition --------------- */
    /* ------------------------------------------------- */

    //private bool HasMoreThanThreeDecimalPlaces(double number)
    //{
    //    //// Kiểm tra số chữ số sau dấu chấm
    //    //string[] parts = number.ToString().Split('.');
    //    //return parts.Length > 1 && parts[1].Length > 3;
    //    return Math.Abs(number * 1000 % 1) > 0;
    //}

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
