using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform player;
    private Vector3 offset;

    private void Start()
    {
        player = FindObjectOfType<Player>().GetComponent<Transform>();
        offset = new Vector3(0, -6, -4);
    }

    private void Update()
    {
        Vector3 position = transform.position;
        position.y = (player.position + offset).y;
        transform.position = position;
    }
}
