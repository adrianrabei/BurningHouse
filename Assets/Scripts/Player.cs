using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    //[SerializeField] private SwipeManager swipeManager;
    //[SerializeField] private List<Transform> positions;
    private Transform player;
    
    private Vector3 movePosition;
    private bool isLeft, isRight, isCenter;
    private int index;
    private CharacterController characterController;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        index = 2;
        player = transform;
    }

    void FixedUpdate()
    {
        float rotationSpeed = Input.GetAxis("Mouse X") * 3f;
        
        player.transform.Translate(Vector3.forward * 10f * Time.deltaTime);

        if (Input.GetMouseButton(0))
        {
            player.transform.RotateAround(player.transform.position, Vector3.back, rotationSpeed);
        }

        //ChangePosition();
    }

    /*private void ChangePosition()
    {
        if (swipeManager.SwipeLeft)
        {
            if (index != positions.IndexOf(positions[0]))
            {
                print("Left");
                index--;
            }
        } 
        else if (swipeManager.SwipeRight)
        {
            if (index != positions.IndexOf(positions[positions.Count - 1]))
            {
                print("Right");
                index++;
            }
        }
        
        characterController.transform.DOMove(positions[index].transform.position, 0.2f);
        player.transform.DOMove(positions[index].transform.position, 0.2f);

        /*if (swipeManager.SwipeLeft)
        {
            if (isRight)
            {
                movePosition += Vector3.left * 3f;
                isCenter = true;
                isRight = isLeft = false;
                print("center");
            }
            else if (isCenter)
            {
                movePosition += Vector3.left  * 3f;
                isLeft = true;
                isRight = isCenter = false;
                print("left");
            }
        }
        if (swipeManager.SwipeRight)
        {
            if (isCenter)
            {
                movePosition += Vector3.right * 3f;
                isRight = true;
                isLeft = isCenter = false;
                print("right");
            }
            else if (isLeft)
            {
                movePosition += Vector3.right * 3f;
                isCenter = true;
                isLeft = isRight = false;
                print("center");
            }
        }

        /*if (transform.position == centralPosition)
        {
            isCenter = true;
            isLeft = isRight = false;
        }
        if (swipeManager.SwipeUp)
        {
            movePosition += Vector3.forward;
        }*/

        //transform.position = Vector3.MoveTowards(transform.position, movePosition, 5f * Time.deltaTime);
        //print(index);

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Obstacle"))
            {
                Time.timeScale = 0;
                print("Game over");
            }
        }
}
