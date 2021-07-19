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
    [SerializeField] private Transform finishPoint;
    [SerializeField] private int waterCount = 0;
    [SerializeField] private SliderController sliderController;

    private Vector3 movePosition;
    private Vector3 direction;
    private int line;
    private bool isOnPosition;
    private Vector3 initialRotation;
    private bool isOnFinish;
    public bool IsActive { get; set; }

    public bool IsOnPosition => isOnPosition;

    public bool IsOnFinish => isOnFinish;

    void Start()
    {
        line = 1;
        initialRotation = transform.rotation.eulerAngles;
    }

    void FixedUpdate()
    {
        if (IsActive)
        {
            if (IsOnPosition != true)
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
            GameManager.Instance.Lose();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Building"))
        {
            if (IsActive)
            {
                isOnFinish = true;
                transform.DOJump(finishPoint.position, 5f, 1, 0.5f);
                transform.rotation = Quaternion.Euler(initialRotation);
                StartCoroutine(OnFinish());
            }
        }

        if (other.CompareTag("Water"))
        {
            Destroy(other.gameObject);
            waterCount++;
            sliderController.Increment(1);
        }
    }

    private IEnumerator OnFinish()
    {
        yield return new WaitForSeconds(0.3f);
        IsActive = false;
        GameManager.Instance.Win();
    }
}
