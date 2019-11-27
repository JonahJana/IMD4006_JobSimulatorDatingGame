using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{

    DialogueParser parser;

    public string dialogue;
    public string dialogue_btns;

    string name_interviewer;

    string CurrentChoice;

    public Text interviewerSay;
    public Text interviewerName;

    int currentButton;
    public Button[] ButtonsChoice;

    public Sprite[] CharacterSprite;

    public GameObject interviewer;

    int lineNum;
    int Sequence;
    int NextSquence;


    bool checkpls;


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

        checkpls = false;
        CurrentChoice = " ";


    }

    // Update is called once per frame
    void Update()
    {
     if(Sequence == NextSquence)
        {
            //Debug.Log("Run once");
            name_interviewer = parser.GetName(lineNum);
            dialogue = parser.GetContent(lineNum);
            interviewer.GetComponent<Image>().sprite = CharacterSprite[parser.GetPose(lineNum)];
            interviewerSay.text = dialogue;
            interviewerName.text = name_interviewer;
            for (int i = 0; i < 4; i++)
            {
                dialogue_btns = parser.GetContent(lineNum + 1 +i);
                ButtonsChoice[i].GetComponentInChildren<Text>().text = dialogue_btns;
                string choice = parser.GetChoice(lineNum + 1 + i);
                ButtonsChoice[i].onClick.AddListener(delegate { test(choice);});
            }
            Sequence = 0;
            NextSquence++;
        }

     if(checkpls)
        {
            CheckOptions();
            checkpls = false;
        }
        


    }

     void OnGUI()
    {
        //dialogue = GUI.TextField(new Rect(100, 400, 600, 200), dialogue, customStyle);
    }

     void test( string choice)
    {
        CurrentChoice = choice;
        checkpls = true;
        //Debug.Log(CurrentChoice);
    }

    void CheckOptions()
    {

        //this is the brute of the engine this case system navigates us in the parser to make sure everything is shown correctly.
        //Debug.Log("tester");
        switch (CurrentChoice)
        {
            
            case "a02": lineNum = 5; Sequence = NextSquence; resetButon(); break;
            case "b01": lineNum = 10; Sequence = NextSquence; resetButon(); break;
            case "b02": lineNum = 15; Sequence = NextSquence; resetButon(); break;
            case "b03": lineNum = 20; Sequence = NextSquence; resetButon(); break;
            case "b04": lineNum = 25; Sequence = NextSquence; resetButon(); break;

        }

    }
    //I remove all the listener from the button cause if we didnt do that they would stack upon each other and cause us a lot of pain
    void resetButon()
    {
        for (int i = 0; i < 4; i++)
        {
           
            ButtonsChoice[i].onClick.RemoveAllListeners();
        }
    }

   

}
