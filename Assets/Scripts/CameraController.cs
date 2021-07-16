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
    private Tween rotationTween;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        offset = new Vector3(0, -5, -12);
        rotation = new Vector3(-50, 0, 0);
        rotationTween = transform.DORotate(rotation, 1f);
        rotationTween.Pause();
    }

    private void Update()
    {
        if (player.IsOnPosition)
        {
            Vector3 position = transform.position;
            position.y = (player.transform.position + offset).y;
            transform.DOMove(position, 0.5f);
            
            if (!rotationTween.IsComplete())
            {
                rotationTween.Play();
            }
            else print("Completed");
        }
    }
}
