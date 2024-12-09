using System.Collections;
using UnityEngine;

public class After_BreakBox : MonoBehaviour
{
    public static After_BreakBox Instance;


    [Header("--- Spawn Items ---")]
    [SerializeField] private GameObject[] item;


    [Header("--- Break Box ---")]
    [SerializeField] private GameObject break_box;


    Vector2 spawnPosition;
    private void Awake()
    {
        if (Instance == null) { Instance = this; }
    }

    private void Start()
    {
      
    }

    public void Manager_Spawn(GameObject G, Transform T)
    {     
        Spawn_Item(T);
    }

    public void Spawn_Item(Transform box)
    {
        for (int i = 0; i < 3; i++) // Loop Spawn Item
        {
            GameObject spawn_item = Instantiate(item[Random.Range(0, item.Length)], box.position, transform.rotation);
            spawn_item.transform.parent = transform;
            //Debug.Log(name + " " + spawn_item);

            box.position += new Vector3(0.8f, 0, 0);
        }
    }

    public void Spawn_BreakBox()
    {

        if (break_box != null)
        {
            break_box.SetActive(true); // Active Break box
            Debug.Log(break_box.name + "  " + name);
            StartCoroutine(DestroyBreakBox(0.5f)); 
        }
    }

    private IEnumerator DestroyBreakBox(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Kiểm tra lại xem break_box có còn tồn tại không trước khi hủy
        if (break_box != null)
        {
            Destroy(break_box);
        }
    }




}
