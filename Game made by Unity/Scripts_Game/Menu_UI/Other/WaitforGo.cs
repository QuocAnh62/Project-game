using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaitforGo : MonoBehaviour
{
    public GameObject PanalWait;
    public GameObject wait2s;
    public GameObject wait3;
    public GameObject wait2;
    public GameObject wait1;
    public GameObject Go;

    private void Start()
    {
        StartCoroutine(WaitForFire());
    }

    IEnumerator WaitForFire()
    {
        yield return new WaitForSeconds(2f);
        wait2s.SetActive(false);
        wait3.SetActive(true);

        yield return new WaitForSeconds(1f);
        wait3.SetActive(false);
        wait2.SetActive(true);

        yield return new WaitForSeconds(1f);
        wait2.SetActive(false);
        wait1.SetActive(true);

        yield return new WaitForSeconds(1f);
        wait1.SetActive(false);
        Go.SetActive(true);

        yield return new WaitForSeconds(1f);
        Go.SetActive(false);
        PanalWait.SetActive(false);
    }

}
