using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active_Boss_Skull : MonoBehaviour
{        
    public static Active_Boss_Skull Instance;
    [SerializeField] private List<GameObject> active_Arena;
    private BoxCollider2D colider;

    private void Awake()
    {
       if(Instance == null) Instance = this;
       colider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(active());
        }
    }

    // Active Arena When player Trigger Boss Skull
    private IEnumerator active()
    {
        yield return new WaitForSeconds(2f);
        AudioManager.Instance.PlayerMusicSkull();

        foreach (GameObject active in active_Arena)
        {
            active.SetActive(true);
        }

        // Unenabled Collisder because not triiger again
        colider.enabled = false;
    }



    /*Unactive Arena when player die*/
    public void UnActive_Arena_Skull()
    {
        AudioManager.Instance.PlayMusicNormalBG();

        foreach (GameObject active in active_Arena)
        {
            active.SetActive(false);
        }
        
        colider.enabled = true; //Enable Collisder
    }



    /* Check destroy this GameObject */
    public void Des_ActiveSkull()
    {
        StartCoroutine(Des());
    }

    private IEnumerator Des()
    {
        yield return new WaitForSeconds(0.7f);
        Destroy(this.gameObject);
    }
}
