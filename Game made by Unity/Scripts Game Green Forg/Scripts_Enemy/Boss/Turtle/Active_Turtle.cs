using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active_Turtle : MonoBehaviour
{
    public static Active_Turtle Instance;
    [SerializeField] private List<GameObject> active_Arena;
    [SerializeField] private List<Collider2D> colider;

    private void Awake()
    {
        if(Instance == null) Instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(active());
        }
    }

    // Active Arena When player Trigger Boss Turtle
    private IEnumerator active()
    {
        yield return new WaitForSeconds(2f);
        AudioManager.Instance.PLayMusicTurtle();
        foreach (GameObject active in active_Arena)
        {
            active.SetActive(true);
        }

        // Enabled Collisder because not triiger again
        foreach (Collider2D colider in colider)
        {
            colider.enabled = false;
        }
    }



    /*Unactive Arena when player die*/
    public void UnActive_Arena_Turtle()
    {
        AudioManager.Instance.PlayMusicNormalBG();

        foreach (GameObject active in active_Arena)
        {
            active.SetActive(false);
        }

        foreach (Collider2D colider in colider)
        {
            colider.enabled = true;
        }
    }

   

    /* Check destroy this GameObject */
    public void Des_ActiveTurlte()
    {
        StartCoroutine(Des());
    }

    private IEnumerator Des()
    {
        yield return new WaitForSeconds(0.7f);
        Destroy(this.gameObject);
    }
}
