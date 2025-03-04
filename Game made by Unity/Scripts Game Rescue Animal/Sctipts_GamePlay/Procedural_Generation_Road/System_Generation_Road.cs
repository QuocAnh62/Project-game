using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class System_Generation_Road : System_DrawGrid
{
    [SerializeField] private Transform container;

    void Start()
    {
        Calcul_CreatRoad();
    }
   
    private void Calcul_CreatRoad()
    {
        for (int x = 0; x < roomSize.x; x++)
        {
            for (int y = 0; y < roomSize.y; y++)
            {
                Creating_Road(x, y);
            }
        }
    }
    private void Creating_Road(float x, float y)
    {
        GameObject road = Instantiate(tile_Road, new Vector3(x, 0, y), Quaternion.identity);
        road.transform.parent = container.transform;
    }
}
