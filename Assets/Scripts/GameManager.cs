using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private Player player;
    private bool isPlay;

    public bool IsPlay => isPlay;

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
}
