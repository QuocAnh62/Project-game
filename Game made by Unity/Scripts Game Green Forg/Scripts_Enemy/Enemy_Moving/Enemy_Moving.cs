using System.Collections;
using UnityEngine;

public class Enemy_Moving : MonoBehaviour
{
    public GameObject PointA;
    public GameObject PointB;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;

    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = PointB.transform;
        
    }
    void Update()
    {
        if(currentPoint == PointB.transform)
        {
            rb.velocity = new Vector2(speed,rb.velocity.y);
            anim.SetFloat("Walk", transform.position.x);
            Flip(speed);
        }
        else if(currentPoint == PointA.transform)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            anim.SetFloat("Walk", transform.position.x);
            Flip(-speed);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == PointB.transform)
        {
            StartCoroutine(Wait_PointA());
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == PointA.transform)
        {
            StartCoroutine(Wait_PointB());              
        }
    }

    IEnumerator Wait_PointA()
    {
        rb.velocity = Vector2.zero;
        anim.SetFloat("Walk", 0f);
        yield return new WaitForSeconds(2f);      
        currentPoint = PointA.transform;
    }

    IEnumerator Wait_PointB()
    {
        rb.velocity = Vector2.zero;
        anim.SetFloat("Walk", 0f);
        yield return new WaitForSeconds(2f);       
        currentPoint = PointB.transform;
    }

    private void Flip(float moveInput)
    {      
        if (moveInput != 0)
        {
            if (moveInput > 0)
            {
                transform.localScale = new Vector3(1, 1, 1); // left
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1); // right
            }
        }      
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(PointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(PointB.transform.position, 0.5f);
        Gizmos.DrawLine(PointA.transform.position, PointB.transform.position);
    }
}

