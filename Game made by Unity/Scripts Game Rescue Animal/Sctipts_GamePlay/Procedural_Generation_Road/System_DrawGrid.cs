using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class System_DrawGrid : Manager_Input_Road
{
    private float cellSize = 1f;
   
    protected void OnDrawGizmos()
    {
       // DrawGrid();
    }

    protected void DrawGrid()
    {
        for (int x = 0; x < roomSize.x; x++)
        {
            for (int y = 0; y < roomSize.y; y++)
            {
                Vector3 position = new Vector3(x * cellSize, 0, y * cellSize);

                Gizmos.color = Color.green;
                Gizmos.DrawWireCube(position, new Vector3(cellSize, 0.1f, cellSize));
            }
        }
    }
}
