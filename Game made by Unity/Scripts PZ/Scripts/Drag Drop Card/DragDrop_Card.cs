using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop_Card : MonoBehaviour
{
    private Collider2D col;

    private Vector3 startDragPos;

    private void Start()
    {
        col = GetComponent<Collider2D>();
    }

    private void OnMouseDown()
    {
        startDragPos = transform.position;
        transform.position = GetMousePositionInWorldSpace();
    }

    private void OnMouseDrag()
    {
        transform.position = GetMousePositionInWorldSpace();
    }

    public Vector3 GetMousePositionInWorldSpace()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0f;
        return pos;
    }
}
