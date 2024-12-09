using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Apple : MonoBehaviour
{
    public static UI_Apple instance;

    public Text scoreApple;

   int score = 0;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        scoreApple.text = "X " + score.ToString();
    }

    public void AddPoints()
    {
        score += 1;
        scoreApple.text = "X " + score.ToString();
    }
}
