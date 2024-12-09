using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check_PlayerWin : MonoBehaviour
{
    public static Check_PlayerWin Instance;
    [Header("----- Part of Turtle ------")]
    [SerializeField] private List<GameObject> unActiveBossTurtle;
    [SerializeField] private List<GameObject> active_SomeArenaTurtle;
    [Header("----- Part of Skull ------")]
    [SerializeField] private List<GameObject> unActiveBossSkull;
    [SerializeField] private List<GameObject> active_SomeArenaSkull;


    private float timeActiveArenaTurtle = 1f;
    private float timeActiveArenaSkull = 0.1f;


    private void Awake()
    {
        if (Instance == null) Instance = this;
    }


    /* Check Setup if player destroy Turtle */
    public void PlayerWin_BossTurtle()
    {
        AudioManager.Instance.PlayMusicNormalBG();
        StartCoroutine(UnActive_And_ActiveArenaTurtle());
    }

    private IEnumerator UnActive_And_ActiveArenaTurtle()
    {
        foreach (GameObject unActive in unActiveBossTurtle)
        {
            unActive.SetActive(false);
        }

        yield return new WaitForSeconds(timeActiveArenaTurtle);

        foreach (GameObject active in active_SomeArenaTurtle)
        {
            active.SetActive(true);
        }
    }




    /* Check Setup if player destroy Skull */
    public void PlayerWin_BossSkull()
    {
        AudioManager.Instance.PlayMusicNormalBG();
        StartCoroutine(UnActive_And_ActiveArenaSkull());       
    } 

    private IEnumerator UnActive_And_ActiveArenaSkull()
    {
        foreach (GameObject unActive in unActiveBossSkull)
        {
            unActive.SetActive(false);
        }

        yield return new WaitForSeconds (timeActiveArenaSkull);

        foreach (GameObject unActive in active_SomeArenaSkull)
        {
            unActive.SetActive(true);
        }
    }

}
