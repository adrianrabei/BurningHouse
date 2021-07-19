using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    private Player player;
    private Vector3 offset;
    private Vector3 rotation;
    private bool finalizedRotation;
    private bool startFollowing;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        offset = new Vector3(0, -5, -12);
        rotation = new Vector3(-50, 0, 0);
    }

    private void Update()
    {
        if (player.IsOnPosition)
        {
            StartCoroutine(StartFollowing());
            
            if (startFollowing)
            {
                Vector3 position = transform.position;
                position.y = (player.transform.position + offset).y;
                transform.position = position;
                
                if (finalizedRotation != true)
                {
                    transform.DORotate(rotation, 1f);
                    StartCoroutine(StopRotation());
                }
            }
        }
    }

    private IEnumerator StopRotation()
    {
        yield return new WaitForSeconds(1f);
        finalizedRotation = true;
    }

    private IEnumerator StartFollowing()
    {
        yield return new WaitForSeconds(0.5f);
        startFollowing = true;
    }
}
