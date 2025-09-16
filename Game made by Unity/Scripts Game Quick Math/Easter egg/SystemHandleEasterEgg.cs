using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SystemHandleEasterEgg : MonoBehaviour
{
    [SerializeField] protected TMP_Text text_Input;
    [SerializeField] protected TMP_Text text_Correct;

    [SerializeField] protected GameObject game_Core;
    [SerializeField] protected GameObject show_Winner;
    [SerializeField] protected GameObject timeOver_Obj;
    [SerializeField] private GameObject musicSource;
    

    public const string egg_Easy = ".--.0.-..0.0.-0...0.";
    public const string egg_Normal = "-..0---0-.0.----.0-0....0..-0.-.0-0--0.";
    public const string egg_Hard = ".--0....0-.--0.-0.-..0.--0.-0-.--0...0--0.";
    public const string egg_Random = "-0.-.0---0.-..0.-..0...-0..0.0-0-.0.-0--";
    public const string egg_Special = "-.-0..0-.0--.0-.-0.0...-0..0-.";

    protected int eggIndex = 0;
    /* ============================================= */
    /* ========== Part of Easter Egg Easy ========== */
    /* ============================================= */
    protected IEnumerator EasterEgg_Easy()
    {
        InActiveObj(false);
        text_Correct.text = "Please";

        SystemLevelUp.instance.Harder();
        GameCore_Easy.time_TurnOff = GameCore_Easy.time_TurnOffText + 0.5f;

        yield return new WaitForSeconds(0.7f);
        TextSize();

        InActiveObj(true);
        timeOver_Obj.SetActive(false);

        Handle_TextInput(true); // Handle text input
        game_Core.GetComponent<GameCore_Easy>().CallExtrem(); // Handle show next Text
    }


    /* =============================================== */
    /* ========== Part of Easter Egg Normal ========== */
    /* =============================================== */
    protected IEnumerator EasterEgg_Normal()
    {
        InActiveObj(false);

        text_Correct.text = "Don't hurt me"; text_Correct.fontSize = 25;

        SystemLevelUpNormal.instance.Harder(); // Handle make game harder
        GameCore_Normal.time_TurnOff = GameCore_Normal.time_TurnOffText + 0.5f;

        yield return new WaitForSeconds(0.7f);

        TextSize();

        InActiveObj(true);
        timeOver_Obj.SetActive(false);

        Handle_TextInput(true); // Handle text input
        game_Core.GetComponent<GameCore_Normal>().CallExtrem(); // Handle show next Text
    }


    /* =============================================== */
    /* ========== Part of Easter Egg Hard ========== */
    /* =============================================== */

    protected IEnumerator EasterEgg_hard()
    {
        InActiveObj(false);

        text_Correct.text = "Why always me"; text_Correct.fontSize = 22;

        SystemLevelUpHard.instance.HarderForEasterEgg(); // Handle make game harder
        GameCore_Hard.time_TurnOff = GameCore_Hard.time_TurnOffText + 0.5f;

        yield return new WaitForSeconds(0.7f);

        TextSize();
        InActiveObj(true);

        Handle_TextInput(true); // Handle text input
        game_Core.GetComponent<GameCore_Hard>().CallExtrem(); // Handle show next Text
    }


    /* =============================================== */
    /* ========== Part of Easter Egg Random ========== */
    /* =============================================== */

    protected IEnumerator EasterEgg_Random()
    {
        InActiveObj(false);

        musicSource.SetActive(false);
        SystemPlayAudio.instance.PlayEffect(SystemAudioInput.instance.egg_Random);
        text_Correct.text = "Troll VietNam"; text_Correct.fontSize = 30;

        LevelUpRandom.instance.Harder(); // Handle make game harder

        yield return new WaitForSeconds(10.5f);


        musicSource.SetActive(true);
        GameCore_Random.time_TurnOff = GameCore_Random.time_TurnOffText + 0.5f;

        TextSize();
        InActiveObj(true);

        Handle_TextInput(true); // Handle text input
        game_Core.GetComponent<GameCore_Random>().CallExtrem(); // Handle show next Text
    }


    /* =============================================== */
    /* ========== Part of Easter Egg Special ========== */
    /* =============================================== */

    protected IEnumerator EasterEgg_Special()
    {
        InActiveObj(false);

        musicSource.SetActive(false);
        SystemPlayAudio.instance.PlayEffect(SystemAudioInput.instance.egg_Special);
        text_Correct.text = "King KEVIN"; text_Correct.fontSize = 30;

        LevelUpRandom.instance.Harder(); // Handle make game harder
       
        yield return new WaitForSeconds(7.5f);

        musicSource.SetActive(true);
        GameCore_Random.time_TurnOff = GameCore_Random.time_TurnOffText + 0.5f;

        TextSize();
        InActiveObj(true);

        Handle_TextInput(true); // Handle text input
        game_Core.GetComponent<GameCore_Random>().CallExtrem(); // Handle show next Text
    }




    private void InActiveObj(bool state)
    {
        game_Core.SetActive(state);
        show_Winner.SetActive(!state);        
    }

    protected void Handle_TextInput(bool isNormalText)
    {
        if (isNormalText)
        {
            text_Input.fontStyle = FontStyles.Italic;
            text_Input.text = "Enter Number";
        }
        else
            text_Input.fontStyle = FontStyles.Bold;
    }

    protected void TextSize()
    {
        text_Correct.fontSize = 33;
        text_Input.fontSize = 33;
    }
}
