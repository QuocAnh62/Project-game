using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle_Skill_2nd : MonoBehaviour
{
    [SerializeField] private GameObject Spikes2_perFab;
    private float time_Spawn = 2f; 
    
    void Start()
    {
        StartCoroutine(Spawn_Spikes2());
    }

    private void OnDisable()
    {
        Destroy(this.gameObject);
    }

    private IEnumerator Spawn_Spikes2()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject spawn = Instantiate(Spikes2_perFab,transform.position + new Vector3(1.3f,0.2f ,0), transform.rotation);
            spawn.transform.parent = transform;
            yield return new WaitForSeconds(time_Spawn);            
        }
        Destroy(this.gameObject, 12f);
    }    
}
