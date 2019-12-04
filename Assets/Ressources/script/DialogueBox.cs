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

    public Image fadeobj;
    bool checkpls;


    public GUIStyle customStyle;


    int Cindypoint = 0;
    int CindySeducepoint = 0;

    bool firsttime = true;

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
        if (firsttime)
        {
            StartCoroutine(Fadein_bg());
            firsttime = false;
        }
        if (Sequence == NextSquence)
        {
            //Debug.Log("Run once");
            name_interviewer = parser.GetName(lineNum);
            dialogue = parser.GetContent(lineNum);
            animatespriteChage();
            interviewerSay.text = dialogue;
            interviewerName.text = name_interviewer;
            for (int i = 0; i < 4; i++)
            {
                dialogue_btns = parser.GetContent(lineNum + 1 + i);
                ButtonsChoice[i].GetComponentInChildren<Text>().text = dialogue_btns;
                string choice = parser.GetChoice(lineNum + 1 + i);
                ButtonsChoice[i].onClick.AddListener(delegate { test(choice); });
            }
            Sequence = 0;
            NextSquence++;
        }

        if (checkpls)
        {
            CheckOptions();
            checkpls = false;
        }



    }

    void OnGUI()
    {
        //dialogue = GUI.TextField(new Rect(100, 400, 600, 200), dialogue, customStyle);
    }

    void test(string choice)
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
            case "b02": addCindypoint(); lineNum = 15; Sequence = NextSquence; resetButon(); break;
            case "b03": lineNum = 20; Sequence = NextSquence; resetButon(); break;
            case "b04": addCindyFlirtpoint(); lineNum = 25; Sequence = NextSquence; resetButon(); break;
            case "c05": lineNum = 30; Sequence = NextSquence; resetButon(); break;
            case "c01": addCindyFlirtpoint(); lineNum = 35; Sequence = NextSquence; resetButon(); break;
            case "c02": lineNum = 40; Sequence = NextSquence; resetButon(); break;
            case "c03": lineNum = 45; Sequence = NextSquence; resetButon(); break;
            case "c04": addCindypoint(); lineNum = 50; Sequence = NextSquence; resetButon(); break;
            case "d05": lineNum = 55; Sequence = NextSquence; resetButon(); break;
            case "d01": addCindypoint(); lineNum = 60; Sequence = NextSquence; resetButon(); break;
            case "d02": addCindyFlirtpoint(); lineNum = 65; Sequence = NextSquence; resetButon(); break;
            case "d03": lineNum = 70; Sequence = NextSquence; resetButon(); break;
            case "d04": lineNum = 75; Sequence = NextSquence; resetButon(); break;
            case "e05": lineNum = 80; Sequence = NextSquence; resetButon(); break;
            case "e01": lineNum = 85; Sequence = NextSquence; resetButon(); break;
            case "e02": addCindypoint(); lineNum = 90; Sequence = NextSquence; resetButon(); break;
            case "e03": addCindyFlirtpoint(); lineNum = 95; Sequence = NextSquence; resetButon(); break;
            case "e04": lineNum = 100; Sequence = NextSquence; resetButon(); break;
            case "f05": selectEndingCindy(); Sequence = NextSquence; resetButon(); break;
            case "End05": StartCoroutine(Fadeinout_bg()); lineNum = 120; Sequence = NextSquence; resetButon(); break;

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

    void selectEndingCindy()
    {
        if (Cindypoint >= 3)
        {
            lineNum = 105;
        }else if (CindySeducepoint >= 3)
        {
            lineNum = 115;
        }
        else
        {
            lineNum = 110;
        }
    }

    void addCindypoint()
    {
        Cindypoint++;
        Debug.Log(Cindypoint);
    }

    void addCindyFlirtpoint()
    {
        CindySeducepoint++;
        Debug.Log(CindySeducepoint);
    }

    void animatespriteChage()
    {
        StartCoroutine(Transition_dude());
       
        
    }

    IEnumerator Transition_dude()
    {
        for (float i = 1; i >= 0; i -= (Time.deltaTime) * 4)
        {

            interviewer.GetComponent<Image>().color = new Color(1, 1, 1, i);
            yield return null;
        }

        for (float i = 0; i <= 1; i += (Time.deltaTime)*4)
            {

            interviewer.GetComponent<Image>().sprite = CharacterSprite[parser.GetPose(lineNum)];
            interviewer.GetComponent<Image>().color = new Color(1, 1, 1, i);
                yield return null;
            }
    }
    
    IEnumerator Fadein_bg()
    {
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {

            fadeobj.color = new Color(0, 0, 0, i);
            yield return null;
        }
    }

    IEnumerator Fadeinout_bg()
    {
        
        for (float i = 0; i <= 1; i += (Time.deltaTime) * 4)
        {
            fadeobj.color = new Color(0, 0, 0, i);
            yield return null;
        }
        for (float i = 1; i >= 0; i -= (Time.deltaTime) * 3)
        {

            fadeobj.color = new Color(0, 0, 0, i);
            yield return null;
        }
    }


}

