using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField] private RectTransform main;
    [SerializeField] private RectTransform game;
    [SerializeField] private RectTransform win;
    [SerializeField] private RectTransform lose;

    private void Update()
    {
        if (GameManager.Instance.IsPlay)
        {
            GoGame();
        }
    }

    private void GoGame()
    {
        main.DOAnchorPos(new Vector2(1080, 0), 0.5f);
        game.gameObject.SetActive(true);
    }
}
