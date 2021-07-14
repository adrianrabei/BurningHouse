using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [SerializeField] private int speed;
    [SerializeField] private int lineDistance;

    private Vector3 movePosition;
    private Vector3 direction;
    private int line;
    private bool isActive;

    void Start()
    {
        line = 1;
        isActive = true;
    }

    void FixedUpdate()
    {
        if (isActive)
        {
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
            if (isActive)
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
            if (isActive)
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
            isActive = false;
            print("Game Over");
        }
    }
}
