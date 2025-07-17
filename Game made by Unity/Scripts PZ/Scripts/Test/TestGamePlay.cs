using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGamePlay : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(Over());
        index();
    }
    private IEnumerator Over()
    {
        yield return new WaitForSeconds(60f);
        Debug.LogError("Stop");
    }

    private void index()
    {
        int minY = Random.Range(-4, 0);
        int maxY = Random.Range(0, 5);
        int i = 0;
        for (int y = minY; y < maxY; y += 1)
        {
            for (int x = -9; x < 3; x += 1)
            {
                i++;               
            }          
        }
        Debug.Log(i);
    }
}
