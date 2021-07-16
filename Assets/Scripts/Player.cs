using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [SerializeField] private int speed;
    [SerializeField] private int lineDistance;
    [SerializeField] private Transform jumpPoint;

    private Vector3 movePosition;
    private Vector3 direction;
    private int line;
    private bool isOnPosition;
    public bool IsActive { get; set; }

    public bool IsOnPosition => isOnPosition;

    void Start()
    {
        line = 1;
    }

    void FixedUpdate()
    {
        if (IsActive)
        {
            if (!IsOnPosition)
            {
                transform.DOMove(jumpPoint.position, 0.5f);
                transform.rotation = Quaternion.Euler(-90, 0, 90);
                isOnPosition = true;
            }
            
            transform.position += Vector3.up * (Time.deltaTime * speed);
        }
    }

    private void Update()
    {
        ChangePosition();
    }

    private void ChangePosition()
    {
        if (SwipeManager.swipeRight)
        {
            if (IsActive)
            {
                if (line < 2)
                {
                    transform.position += new Vector3(lineDistance, 0, 0);
                    line++;
                }
            }
        } 
        
        if (SwipeManager.swipeLeft)
        {
            if (IsActive)
            {
                if (line > 0)
                {
                    transform.position += new Vector3(-lineDistance, 0, 0);
                    line--;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            IsActive = false;
            print("Game Over");
        }
    }
}
