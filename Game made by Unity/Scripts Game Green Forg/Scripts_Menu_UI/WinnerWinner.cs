using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinnerWinner : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            StartCoroutine(Load());
    }

    private IEnumerator Load()
    {
        AudioManager.Instance.PlayEffect(AudioManager.Instance.winner);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("End");
    }
}
