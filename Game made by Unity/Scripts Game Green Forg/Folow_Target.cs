using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Folow_Target : MonoBehaviour
{
    [SerializeField] protected Transform target;

    protected virtual void FixedUpdate()
    {
        this.Following();
    }

    protected virtual void Following()
    {
       transform.position = target.position + new Vector3(-2f,4f,0f);
    }
    
}
