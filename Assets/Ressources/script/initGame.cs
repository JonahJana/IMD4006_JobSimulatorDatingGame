using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class initGame : MonoBehaviour
{
    public Button startGame;
    public Button Quit

    // Start is called before the first frame update
    void Start()
    {
        startGame.onClick.AddListener(StartTheGame);

        Quit.onClick.AddListener(QuitTheGame);
    }

    void StartTheGame()
    {
        SceneManager.LoadScene("SceneTemplate", LoadSceneMode.Single);
    }

    void QuitTheGame()
    {
        Application.Quit();
    }
}
