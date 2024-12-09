using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Support : MonoBehaviour
{
    [SerializeField] private GameObject[] item_perfab;
    public float time_SpawnItems = 7f;
    private List<GameObject> item = new List<GameObject>(); 

    private void OnEnable()
    {       
       StartCoroutine(spawn_Items());      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(spawn_Items());
            item.Clear();
        }           
    }

    private IEnumerator spawn_Items()
    {
        yield return new WaitForSeconds(time_SpawnItems);

        if (item.Count == 0)
        {
            GameObject items = 
             Instantiate(item_perfab[Random.Range(0, item_perfab.Length)], transform.position, Quaternion.identity);

            this.item.Add(items); // add gameObject(items) on new list <gameObject> item

            items.transform.parent = transform;
        }
        else yield return null;

    }
}
