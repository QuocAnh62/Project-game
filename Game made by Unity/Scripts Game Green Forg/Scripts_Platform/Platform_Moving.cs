using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Moving : MonoBehaviour
{
    //public float speed;
    //public int PointStart;
    //private int i; // index of the arry

    //public Transform[] Points;

    //void Start()
    //{
    //    transform.position = Points[PointStart].position;
    //}


    //void Update()
    //{
    //    // checking the distance of the platform and the point
    //    if (Vector2.Distance(transform.position, Points[i].position) < 0.02f)
    //    {
    //        i++; // increase the index
    //        if (i == Points.Length) // check if the platform was on the last point after the index increase
    //        {
    //            i = 0; // reset index
    //        }
    //    }

    //    // Moving the pltform to the point position With the index "i"
    //    transform.position = Vector2.MoveTowards(transform.position, Points[i].position, speed * Time.deltaTime);
    //}


    public GameObject PointA;
    public GameObject PointB;
    private Rigidbody2D rb;
    private Transform currentPoint;

    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = PointA.transform;
    }
    void Update()
    {

        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == PointB.transform)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == PointB.transform)
        {
            currentPoint = PointA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == PointA.transform)
        {
            currentPoint = PointB.transform;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}
