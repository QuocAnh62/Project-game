using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
using Pathfinding;
using UnityEngine.XR;

public class Skull_Moving : MonoBehaviour
{
    [SerializeField] private Transform startPoint;
    [SerializeField] private float nextWayPoints = 3f;

    Path path;
    private int currentWaypoint = 0;
    //bool endOfpath = false;

    private Seeker seeker;
    private Rigidbody2D rb;    

    private void Start()
    {
        
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 2f, .2f);
    }

    private void OnEnable()
    {
        this.transform.position = startPoint.position;
    }

    void UpdatePath()
    {   
        if (seeker.IsDone())
        {
            float distanceToKeep = 9f;

            Vector3 directionToPlayer = ((Vector2)Data_Player.Instance.trsForm_Player.position - rb.position).normalized;
         
            Vector3 targetPosition = Data_Player.Instance.trsForm_Player.position - directionToPlayer * distanceToKeep;
            
            seeker.StartPath(rb.position, targetPosition, OnPathComplete);           
        }
    }

    protected void Update()
    {        
        Flip();
    }

    private void FixedUpdate()
    {       
        Calculater();
    }

    private void Calculater()
    {    

        if (path == null) return;
        
        if (currentWaypoint >= path.vectorPath.Count)
        {        
            return;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * Specifications.Instance.speed_Skull * Time.deltaTime;


        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWayPoints)
        {
            currentWaypoint++;
        }
    }

    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    private void Flip()
    {
        if (transform.position.x > Data_Player.Instance.trsForm_Player.position.x)
            transform.rotation = Quaternion.Euler(0, 180, 0);
        else transform.rotation = Quaternion.Euler(0, 0, 0);      
    }






    //private void Active_sensor()
    //{
    //    //Sensor_LinePlayer();
    //    //testLine();
    //    //Active_sensorCube();
    //    //Sensor_Circle();
    //}


    //protected void Moving()
    //{
    //    //Vector3 a = new Vector3(0.8f, 4.5f, 0);
    //    Vector3 distance = Data_Base.Instance.Player.transform.position - transform.position;

    //    if (distance.magnitude >= 1f)
    //    {
    //        Vector3 targetPoint = Data_Base.Instance.Player.transform.position - distance.normalized * 13f;
    //        gameObject.transform.position =
    //            Vector3.MoveTowards(gameObject.transform.position, targetPoint, speed * Time.deltaTime);
    //    }
    //}

}
