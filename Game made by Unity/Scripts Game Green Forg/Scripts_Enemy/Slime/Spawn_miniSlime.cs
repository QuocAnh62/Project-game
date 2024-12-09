using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawn_miniSlime : MonoBehaviour
{
    public static Spawn_miniSlime Instance;
    [SerializeField] protected GameObject slime_Perfab;
    private void Awake()
    {
        if(Instance == null) Instance = this;
    }

    public void spawn_miniSline(Transform slime)
    {
        //StartCoroutine(spawn(slime)); 
        int index = UnityEngine.Random.Range(1, 3);

        for (int i = 0; i < index; i++)
        {
            GameObject mini_Slime 
                = Instantiate(slime_Perfab, slime.position + new Vector3(0, 0.5f, 0), Quaternion.identity);

            mini_Slime.transform.parent = transform;
        }
    }

    IEnumerator spawn(Transform slime)
    {     
        yield return new WaitForSeconds(0.2f);

        int index = UnityEngine.Random.Range(1, 3);

        for (int i = 0; i < index; i++)
        {
            GameObject mini_Slime = Instantiate(slime_Perfab, slime.position, Quaternion.identity);
            mini_Slime.transform.parent = transform;
        }
    }
}
