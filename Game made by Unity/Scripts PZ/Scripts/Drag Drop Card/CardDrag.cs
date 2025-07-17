using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Card_Type cardType;
    public Transform point;
    private Canvas canvas;


    private Vector3 originalPoint;
    private Vector2 offset;

    void Start()
    {
        canvas = GetComponentInParent<Canvas>();
        originalPoint = transform.localPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!RectTransformUtility.RectangleContainsScreenPoint(
            transform as RectTransform,
            eventData.position,
            canvas.worldCamera))
        {
            return; // Không chạm vào card → không kéo
        }

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            eventData.position,
            canvas.worldCamera,
            out Vector2 localPoint
        );

        offset = (Vector2)transform.localPosition - localPoint;
    }

    public void OnDrag(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            eventData.position,
            canvas.worldCamera,
            out Vector2 localPoint
        );

        transform.localPosition = localPoint + offset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(eventData.position);
        RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);

        if (hit.collider != null && hit.collider.name == "Grid(Clone)")
        {
             SpawnPlant(hit);
        }

        // Reset vị trí card về chỗ cũ nếu cần
        transform.localPosition = originalPoint;
    }

    private void SpawnPlant(RaycastHit2D hit) // Handle spawn type plant
    {
        switch (cardType)
        {
            case Card_Type.SunFlower:
                foreach (GameObject sunFlower in ManagerSpawnAndPool.instance.poolSunFlower)
                {
                    if (!sunFlower.activeInHierarchy)
                    {
                        sunFlower.SetActive(true);
                        sunFlower.transform.position = hit.collider.transform.position;
                        break;
                    }
                }
                break;

            case Card_Type.ShotPlant:               
                foreach (GameObject plantShot in ManagerSpawnAndPool.instance.poolHero)
                {
                    if (!plantShot.activeInHierarchy)
                    {
                        plantShot.SetActive(true);
                        plantShot.transform.position = hit.collider.transform.position;
                        break;
                    }
                }
                break;

        }
    }
}
