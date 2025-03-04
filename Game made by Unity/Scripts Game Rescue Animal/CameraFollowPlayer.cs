using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform Player;

    void Update()
    {
        transform.position = Player.position + new Vector3(0,35,-70);
    }
}
