using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class initGame : MonoBehaviour
{
    public Button startGame;
    public Button Quit;
    public Button How;
    
    public Text explainText;
    public Image explaintBG;

    bool Show = true; 

    // Start is called before the first frame update
    void Start()
    {
        startGame.onClick.AddListener(StartTheGame);

        Quit.onClick.AddListener(QuitTheGame);
        How.onClick.AddListener(ShowExplanation);
        explainText.color = new Color(1, 1, 1, 0);
        explaintBG.color = new Color(1, 1, 1, 0);
    }


     void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    void StartTheGame()
    {
        SceneManager.LoadScene("Parser_test_game", LoadSceneMode.Single);
    }

    void QuitTheGame()
    {
        Application.Quit();
    }

    void ShowExplanation()
    {
        if (Show)
        {
            explainText.color = new Color(1, 1, 1, 1);
            explaintBG.color = new Color(1, 1, 1, 1);
            Show = false;
        }
        else
        {
            explainText.color = new Color(1, 1, 1, 0);
            explaintBG.color = new Color(1, 1, 1, 0);
            Show = true;
        }

    }
}
