using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSpawnChicken : MonoBehaviour
{
     public GameObject chicken;
    void Start()
    {
        StartCoroutine(ActiveChickien());
    }

    private void OnEnable()
    {
        StartCoroutine(ActiveChickien());
    }

    private IEnumerator ActiveChickien()
    {
        yield return new WaitForSeconds(0.5f);
        while (true)
        {          
            switch(Random.Range(0, 2))
            {
                case 0:
                    chicken.transform.position = new Vector3(-100, Random.Range(350, 1500), 0);
                    chicken.transform.rotation = Quaternion.Euler(0, 180, 0);
                    break;
                case 1:
                    chicken.transform.position = new Vector3(1100, Random.Range(350, 1500), 0);
                    chicken.transform.rotation = Quaternion.identity;
                    break;
            }           
            chicken.SetActive(true);
            yield return new WaitForSeconds(5);
        }
        
    }
}
