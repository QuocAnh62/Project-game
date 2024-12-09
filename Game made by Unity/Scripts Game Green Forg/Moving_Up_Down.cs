using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Up_Down : MonoBehaviour
{
    private float amplitude = 0.25f;
    private float speed = 4.5f;
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        float newY = startPosition.y + Mathf.Sin(Time.time * speed) * amplitude;

        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}
