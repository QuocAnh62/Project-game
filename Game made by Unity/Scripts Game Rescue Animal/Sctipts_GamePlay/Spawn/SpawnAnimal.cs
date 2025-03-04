using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnAnimal : MonoBehaviour
{
    [SerializeField] private Vector2 pos_Spawn;
    public List<GameObject> animal_Perfab;
    public GameObject point_Center;
    public Transform local_Spawn;
    public float circleRadius;
    public int numberOfCircle;

    void Start()
    {
        transform.position = new Vector3(pos_Spawn.x, 0, pos_Spawn.y);
        SpawnAnimals();       
        //StartCoroutine(ResetA());
        //StartCoroutine(SpawnCircle());
    }


    private void SpawnAnimals()
    {
        Vector3 direction = Random.insideUnitCircle.normalized;
        var distance = Random.Range(7, 20); 
        Vector3 posZ = new Vector3(0, 0, Random.Range(-distance, distance));
        Vector3 posX = direction * distance;

        Vector3 a = point_Center.transform.position + new Vector3(posX.x, 0.2f, posZ.z);

        GameObject plt = Instantiate(animal_Perfab[Random.Range(0, animal_Perfab.Count)], a, Quaternion.identity);
        plt.transform.parent = local_Spawn; // move gameObject spawn at GameObject Manager Spawn(Clone)
    }

    private IEnumerator ResetA()
    {
        while (true)
        {
            Vector3 direction = Random.insideUnitCircle.normalized;
            var distance = Random.Range(7, 20); // for e.g 7 is min and 15 max
            Vector3 posZ = new Vector3(0,0, Random.Range(-distance,distance));
            Vector3 posX = direction * distance;

            GameObject plt = Instantiate(animal_Perfab[Random.Range(0, animal_Perfab.Count)]);
            plt.transform.position = point_Center.transform.position + new Vector3(posX.x, 0, posZ.z);

            yield return new WaitForSeconds(1f);
            Destroy(plt);
        }
    }

    private IEnumerator SpawnCircle()
    {
        for(int i = 0; i <= numberOfCircle; i++) 
        {

            float segment = 2 * Mathf.PI * i/numberOfCircle;
            float horizontal = Mathf.Cos(segment);
            float vertical = Mathf.Sin(segment);

            Vector3 dirValue = new Vector3(-horizontal, 0, vertical);
            Vector3 worldPos = point_Center.transform.position + dirValue * circleRadius;

            GameObject C = 
                Instantiate(animal_Perfab[Random.Range(0, animal_Perfab.Count)], worldPos, Quaternion.identity);

            yield return new WaitForSeconds(1f);
            //Destroy (C);
        }

    }
}
