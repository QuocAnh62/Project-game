using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brid_Fly_A : MonoBehaviour
{
    [SerializeField] private List<Transform> points;
    [SerializeField] private Transform pointStart_B;
    private float speed = 3f; 
    private int Cout = 0;

    private void Start()
    {
        transform.position = pointStart_B.position;
    }

    private void Update()
    {
        Moving();
    }

    private void Moving()
    {
        if(transform.position == points[Cout].position)
        {
            PlusCout();
        }
        transform.position = Vector3.MoveTowards(transform.position, points[Cout].position, speed * Time.deltaTime);
    }

    private void PlusCout()
    {
        Cout++;

        if(Cout > 1) Cout = 0;

        Flip(Cout);
    }


    void Flip(int cout)
    {
        if (cout == 0)
        {
            transform.localScale = Vector3.one;
        }

        else if (cout == 1)
        {
            transform.localScale =  new Vector3(-1, 1, 0);
        }                    
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(points[0].position, points[1].position);
    }
}
