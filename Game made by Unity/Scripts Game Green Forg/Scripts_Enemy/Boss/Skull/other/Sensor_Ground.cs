using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Sensor_Ground : MonoBehaviour
{
    //public LayerMask isTile;
    //public float radius;
    //public Vector2 boxsize;
    //public float castdis;

    //private Vector3 direction;
    //private Rigidbody2D rb;
    //void Start()
    //{
    //    rb = GetComponent<Rigidbody2D>();
    //}
    //protected void Sensor_Circle()
    //{        
    //    Collider2D[] check = Physics2D.OverlapCircleAll(transform.position, radius, isTile);

    //    foreach (Collider2D move in check)
    //    {
            
    //        if (move.CompareTag("TileUp"))
    //        {              
    //            // Tính toán hướng tác động
    //            direction = move.transform.position - transform.position;
    //            MoveAwayDown(direction);
    //            break;
                
    //        }

    //        else if (move.CompareTag("TileDown"))
    //        {
    //            //// Lấy vị trí collider
    //            //colliderPosition = move.transform.position;

    //            // Tính toán hướng tác động
    //            direction = move.transform.position - transform.position;
    //            MoveAwayUp(direction);
    //            break;

    //        }
    //    }
    //}

    //private void MoveAwayUp(Vector3 direction)
    //{
    //    Vector3 awayDirection = direction.normalized; // Hướng ra khỏi collider
    //    transform.position -= awayDirection * 9f * Time.deltaTime; // Move Up 
    //}

    //private void MoveAwayDown(Vector3 direction)
    //{
    //    Vector3 awayDirection = direction.normalized; // Hướng ra khỏi collider
    //    transform.position += awayDirection * 9f * Time.deltaTime; // Move Down
    //}


    //protected void Sensor_LinePlayer()
    //{
    //    //RaycastHit2D[] hits = Physics2D.LinecastAll(transform.position, Data_Base.Instance.Player.position);

    //    //// Duyệt qua tất cả các va chạm
    //    //foreach (RaycastHit2D hit in hits)
    //    //{
    //    //    if (hit.collider.CompareTag("Player"))
    //    //    {
    //    //        Debug.Log("Hit player: ");
    //    //        Debug.DrawLine(transform.position, Data_Base.Instance.Player.position, Color.red);
    //    //    }
    //    //    else
    //    //    {
    //    //        Debug.Log("Blocked by: ");
    //    //        Debug.DrawLine(transform.position, hit.point, Color.black);
    //    //    }
    //    //}    
       
    //    //foreach(RaycastHit2D checkPlayer in hit)
    //    //{            
       
    //    //}
    //}


    //protected void testLine()
    //{
    //    Vector2 start = transform.position; // Vị trí của đối tượng này
    //    Vector2 end = Data_Base.Instance.Player.position; // Vị trí của player

    //    // Kiểm tra va chạm bằng LinecastAll
    //    RaycastHit2D[] hits = Physics2D.LinecastAll(start + new Vector2(3f,0), end);

    //    // Kiểm tra xem có va chạm không
    //    if (hits.Length > 0)
    //    {
    //        // Duyệt qua tất cả các va chạm
    //        foreach (RaycastHit2D hit in hits)
    //        {
    //            if (hit.collider.CompareTag("Player"))
    //            {
    //                Debug.Log("Hit player: " + hit.collider.name);
    //               // Debug.DrawLine(start, end, Color.red); // Vẽ đường thẳng đỏ đến player
    //            }
    //            else
    //            {                   
    //                Debug.Log("Blocked by: " + hit.collider.name);
                   
    //            }
    //            Debug.DrawRay(start, end, Color.black, 10f); // Vẽ đường thẳng đen đến vật thể bị chặn
    //        }

    //    }

    //}


    //protected void Active_sensorCube()
    //{
    //    Sensor_Cubeleft();
    //    Sensor_Cuberight();
    //}

    //private void Sensor_Cubeleft()
    //{
    //   RaycastHit2D hit = Physics2D.BoxCast(transform.position, boxsize, 0, -transform.right, castdis, isTile);
    //    if(hit.collider != null)
    //    {
    //        Debug.Log("left");
    //        //rb.velocity = Vector2.right * 9f;
    //    }
       
    //}

    //private void Sensor_Cuberight()
    //{
    //    RaycastHit2D hit = Physics2D.BoxCast(transform.position, boxsize, 0, transform.right, castdis, isTile);       
    //    if (hit.collider != null)
    //    {
    //        Debug.Log("right");
    //        //rb.velocity = Vector2.left * 9f;
    //    }
        
    //}


    //protected void OnDrawGizmosSelected()
    //{
    //    if (transform.position == null) return;
    //    Gizmos.DrawWireSphere(transform.position, radius);

    //    Gizmos.DrawWireCube(transform.position + transform.right * castdis, boxsize);
    //    Gizmos.DrawWireCube(transform.position - transform.right * castdis, boxsize);

    //    //Gizmos.DrawLine(transform.position, Data_Base.Instance.Player.position);
    //}


}
