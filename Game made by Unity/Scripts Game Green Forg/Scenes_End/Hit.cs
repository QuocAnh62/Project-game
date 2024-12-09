using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    private Animator animator; // Animator để quản lý animation

    void Start()
    {
        animator = GetComponent<Animator>(); // Lấy component Animator
    }

    void OnMouseDown() // Khi nhấp chuột vào đối tượng
    {
        StartCoroutine(hit());
    }

    IEnumerator hit()
    {
        animator.SetBool("Hit", true);
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("Hit", false);
    }
}
