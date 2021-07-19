using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private Player player;
    private bool isPlay;
    private bool isLose;
    private bool isWin;

    public bool IsPlay => isPlay;

    public bool IsLose => isLose;

    public bool IsWin => isWin;

    private void Awake()
    {
        Instance = this;
        player = FindObjectOfType<Player>();
    }

    public void Play()
    {
        isPlay = true;
        player.IsActive = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Lose()
    {
        isLose = true;
        isPlay = false;
    }

    public void Win()
    {
        isWin = true;
        isPlay = false;
    }
}
