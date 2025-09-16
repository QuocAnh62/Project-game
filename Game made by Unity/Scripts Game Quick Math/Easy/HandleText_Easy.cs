using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HandleText_Easy : MonoBehaviour
{
    [SerializeField] protected TMP_Text text_Input;
    [SerializeField] protected TMP_Text text_Score;
    [SerializeField] protected TMP_Text text_ScoreLose;
    [SerializeField] protected TMP_Text text_Correct;

    [SerializeField] protected GameObject game_Core;
    [SerializeField] protected GameObject show_Winner;
    [SerializeField] protected GameObject show_GameOver;
    [SerializeField] protected GameObject getBack;


    protected int cout = 0;
    protected int maxCount = 45;


    protected void TextInput(string input)
    {
        cout++;
        Handle_TextInput(false); // Handle text input
        if (cout < maxCount)
        {
            if (text_Input.text == "Enter Number") { text_Input.text = input; }
            else { text_Input.text = text_Input.text + input; }

            AdjustFontSize("input");
        }
    }

    protected void AdjustFontSize(string function) // Handle fornt size text input
    {
        if (cout > 13 && cout < maxCount)
        {
            if (text_Input.fontSize > 15 && function == "input") { text_Input.fontSize--; }

            if (cout % 2 == 0 && text_Input.fontSize < 33 && function == "delete") { text_Input.fontSize++; }
        }
        if (cout == 13) { text_Input.fontSize = 33; }
    }

    protected IEnumerator GamePlay() // Handle When Sibmit is correct
    { 
        show_Winner.SetActive(true);
        game_Core.SetActive(false);

        SystemLevelUp.instance.Harder();
        text_Correct.text = "Correct";

        yield return new WaitForSeconds(0.7f);

        show_Winner.SetActive(false);
        game_Core.SetActive(true);

        Handle_TextInput(true); // Handle text input
        game_Core.GetComponent<GameCore_Easy>().CallExtrem(); // Handle show next Text
    }
   


    protected void Handle_TextInput(bool isNormalText)
    {
        if (isNormalText)
        {
            text_Input.fontStyle = FontStyles.Italic;
            text_Input.text = "Enter Number";
        }
        else text_Input.fontStyle = FontStyles.Bold;
    }
}
