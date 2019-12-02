using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class intro_progression : MonoBehaviour
{

    public string nextSceneName;
    public Button contBtn;

    public Text txtBox;

    // Start is called before the first frame update
    void Start()
    {
        contBtn.onClick.AddListener(nextTxt);
        txtBox.text = "this is the intro section";
    }

    void nextTxt()
    {
        SceneManager.LoadScene(nextSceneName, LoadSceneMode.Single);
    }
}
