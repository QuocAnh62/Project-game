using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal_Run : MonoBehaviour
{
    Rigidbody rb;
    private Vector3 s_dirWithPlayer;
    protected bool isRun = false;

    protected void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        CalculComeNear();
        // check position player with animal if player nearby animal, animal run
        if (s_dirWithPlayer.magnitude <= 25f)
        {
            isRun = true;
        }
        // check position player with animal if player nearby animal, animal stop
        else if (s_dirWithPlayer.magnitude > 45f)
        {

            isRun = false;
        }
    }

    protected void FixedUpdate()
    {
        run();
    }

    protected void CalculComeNear() // calculate if player nearby animal. Then animal run
    {
        s_dirWithPlayer = Manager_Input.Instance.transformPlayer.position - transform.position;
        Vector3 dirWithLine = Manager_Input.Instance.finish_Line1.position - transform.position;      
    }

    protected void run() // animal Run
    {
        if (isRun == true)
        {
            rb.velocity = Vector3.forward * PlayerPrefs.GetFloat("Speed Animal");
        }
        else 
        {
            rb.velocity = Vector3.zero;
        }

    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            rb.velocity = Vector3.zero;
            Destroy(GetComponent<Animal_Run>());
        }
    }
}
