using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardDrag : MonoBehaviour/*, IBeginDragHandler*/, IDragHandler, IEndDragHandler
{
    public GameObject plantPrefab;
    private Canvas canvas;
    public Transform point;

    private Vector3 originalPoint;

    void Start()
    {
        canvas = GetComponentInParent<Canvas>();
        originalPoint = transform.localPosition;
    }

    //public void OnBeginDrag(PointerEventData eventData) { }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(eventData.position);
        RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);

        if (hit.collider != null && hit.collider.name == "Grid(Clone)")
        {
            //Instantiate(plantPrefab, hit.collider.transform.position, Quaternion.identity);
            foreach(GameObject hero in ManagerSpawnAndPool.instance.poolHero)
            {
                if (!hero.activeInHierarchy)
                {
                    hero.SetActive(true);
                    hero.transform.position = hit.collider.transform.position;
                    break;
                }
            }
        }

        // Reset vị trí card về chỗ cũ nếu cần
         //transform.localPosition = point.position;
        transform.localPosition = originalPoint;

    }
}
