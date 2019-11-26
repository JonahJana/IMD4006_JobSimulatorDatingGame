using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{

    DialogueParser parser;

    public string dialogue;
    public string dialogue_btns;
    string CurrentChoice;
    int currentButton;
    public Button[] ButtonsChoice;

    int lineNum;
    int Sequence;
    int NextSquence;

    public GUIStyle customStyle;

    // Start is called before the first frame update
    void Start()
    {
        dialogue_btns = " ";
        dialogue = " ";
        parser = GameObject.Find("DialogueParserObj").GetComponent<DialogueParser>();
        Sequence = 0;
        lineNum = 0;
        NextSquence = 0;


    }

    // Update is called once per frame
    void Update()
    {
     if(Sequence == NextSquence)
        {
            dialogue = parser.GetContent(lineNum);
           
            for(int i = 0; i < 4; i++)
            {
                dialogue_btns = parser.GetContent(lineNum + 1 +i);
                ButtonsChoice[i].GetComponentInChildren<Text>().text = dialogue_btns;
                string choice = parser.GetChoice(lineNum + 1 + i);
                ButtonsChoice[i].onClick.AddListener(delegate { test(choice);});
            }
            NextSquence++;
        }
         
    }

     void OnGUI()
    {
        dialogue = GUI.TextField(new Rect(100, 400, 600, 200), dialogue, customStyle);
    }

     void test( string choice)
    {
        CurrentChoice = choice;
        Debug.Log(CurrentChoice);
    }

    void CheckOptions()
    {


    }
}
