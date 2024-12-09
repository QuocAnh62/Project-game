using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMaps : MonoBehaviour
{
    public Transform GetTransform;
    public float currentDis = 0f;
    public float limitDis;
    public float respawnDis;

    private void FixedUpdate()
    {
        Sapwning();
        GetDistance();
    }
    void Sapwning()
    {
        if (currentDis < limitDis) return;       
        Vector3 pos = transform.position;
        pos.x += respawnDis;
        transform.position = pos;
    }

    void GetDistance()
    {
        currentDis = GetTransform.position.x - transform.position.x;
    }
}
