using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMiniBoss : MonoBehaviour
{
    public GameObject DieUp;
    public GameObject DieDown;
    public GameObject Miniboss;

    void Update()
    {
        Vector3 DirUp = DieUp.transform.position - transform.position;
        Debug.Log(DirUp);
        if (DirUp.y > 11)
        {
            Debug.Log(DirUp);
            StartCoroutine(MiniBoss_Up());
        }
        Vector3 DirDown = DieDown.transform.position - transform.position;
    }

    IEnumerator MiniBoss_Up()
    {
        Instantiate(Miniboss);
        yield break;
    }
}
