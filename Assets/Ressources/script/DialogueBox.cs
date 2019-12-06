using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    
    DialogueParser parser;

    public float delayTexAnimation = 0.0001f;

    public string dialogue;

    public string CurrentDialogue = " ";
    public string dialogue_btns;

    string name_interviewer;

    string CurrentChoice;

    public Text interviewerSay;
    public Text interviewerName;

    int currentButton;
    public Button[] ButtonsChoice;

    public Sprite[] CharacterSprite;


    public AudioSource VoiceInterview;
    public AudioClip[] voiceLine;

    public GameObject interviewer;

    int lineNum;
    int Sequence;
    int NextSquence;

    public Image fadeobj;
    bool checkpls;


    public GUIStyle customStyle;


    int Cindypoint = 0;
    int CindySeducepoint = 0;

    int totalCinPts =0;

    int Eastonpoint = 0;
    int EastonpointSeduce = 0;

    int totalEastPts = 0;

    int ChipPoint = 0;
    int ChipFlirtpoint = 0;

    int totalChipPts = 0;

    bool firsttime = true;
    bool akward = false;
    bool loveMode = false;
    //here we will handle all the transitionnal effects
    public Image love;
    public Image bgAkward;
    public Image faceAkward;


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
            PlayAudioLine(parser.GetValue(lineNum));
            animatespriteChage();
            StartCoroutine(TypeText());
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
            case "b03":  lineNum = 20; Sequence = NextSquence; resetButon(); badSitution(); break;
            case "b04": addCindyFlirtpoint(); lineNum = 25; Sequence = NextSquence; resetButon(); break;
            case "c05": lineNum = 30; Sequence = NextSquence; resetButon(); Resetbg(); break;
            case "c01": addCindyFlirtpoint(); lineNum = 35; Sequence = NextSquence; resetButon(); break;
            case "c02": lineNum = 40; Sequence = NextSquence; resetButon(); badSitution(); break;
            case "c03": lineNum = 45; Sequence = NextSquence; resetButon(); break;
            case "c04": addCindypoint(); lineNum = 50; Sequence = NextSquence; resetButon(); break;
            case "d05": lineNum = 55; Sequence = NextSquence; resetButon(); Resetbg(); break;
            case "d01": addCindypoint(); lineNum = 60; Sequence = NextSquence; resetButon(); break;
            case "d02": addCindyFlirtpoint(); lineNum = 65; Sequence = NextSquence; resetButon(); break;
            case "d03": lineNum = 70; Sequence = NextSquence; resetButon(); break;
            case "d04": lineNum = 75; Sequence = NextSquence; resetButon(); badSitution(); break;
            case "e05": lineNum = 80; Sequence = NextSquence; resetButon(); Resetbg(); break;
            case "e01": lineNum = 85; Sequence = NextSquence; resetButon(); break;
            case "e02": addCindypoint(); lineNum = 90; Sequence = NextSquence; resetButon(); break;
            case "e03": addCindyFlirtpoint(); lineNum = 95; Sequence = NextSquence; resetButon(); break;
            case "e04": lineNum = 100; Sequence = NextSquence; resetButon(); badSitution(); break;
            case "f05":  Sequence = NextSquence; resetButon(); Resetbg(); selectEndingCindy();break;
            case "End05": StartCoroutine(Fadeinout_bg()); lineNum = 120; Sequence = NextSquence; resetButon(); Resetbg(); break;
            case "g05":lineNum = 125; Sequence = NextSquence; resetButon(); Resetbg(); break;
            case "g01": addEpoint(); lineNum = 130; Sequence = NextSquence; resetButon(); break;
            case "g02": lineNum = 135; Sequence = NextSquence; resetButon(); break;
            case "g03": lineNum = 140; Sequence = NextSquence; resetButon(); badSitution(); break;
            case "g04": addEFlirtpoint(); lineNum = 145; Sequence = NextSquence; resetButon(); break;
            case "h05": lineNum = 150; Sequence = NextSquence; resetButon(); Resetbg(); break;
            case "h01": lineNum = 155; Sequence = NextSquence; resetButon(); break;
            case "h02": addEFlirtpoint(); lineNum = 160; Sequence = NextSquence; resetButon(); break;
            case "h03":  addEpoint(); lineNum = 165; Sequence = NextSquence; resetButon(); break;
            case "h04":  lineNum = 170; Sequence = NextSquence; resetButon(); badSitution(); break;
            case "i05": lineNum = 175; Sequence = NextSquence; resetButon(); Resetbg(); break;
            case "i01":addEpoint(); lineNum = 180; Sequence = NextSquence; resetButon(); break;
            case "i02": addEFlirtpoint(); lineNum = 185; Sequence = NextSquence; resetButon(); break;
            case "i03":  lineNum = 190; Sequence = NextSquence; resetButon(); break;
            case "i04": lineNum = 195; Sequence = NextSquence; resetButon(); badSitution(); break;
            case "k05": lineNum = 200; Sequence = NextSquence; resetButon(); Resetbg(); break;
            case "k01":  lineNum = 205; Sequence = NextSquence; resetButon(); badSitution(); break;
            case "k02": addEpoint(); lineNum = 210; Sequence = NextSquence; resetButon(); break;
            case "k03": addEFlirtpoint(); lineNum = 215; Sequence = NextSquence; resetButon(); break;
            case "k04": lineNum = 220; Sequence = NextSquence; resetButon();  break;
            case "l05":  Sequence = NextSquence; resetButon(); Resetbg(); selectEndingEaston();break;
            case "EndB05": StartCoroutine(Fadeinout_bg()); lineNum = 240; Sequence = NextSquence; resetButon(); Resetbg(); break;
            case "m05": lineNum = 245; Sequence = NextSquence; resetButon(); Resetbg(); break;
            case "m01": lineNum = 250; Sequence = NextSquence; resetButon(); break;
            case "m02": lineNum = 255; Sequence = NextSquence; resetButon(); badSitution(); break;
            case "m03": ChipFlirtPoint(); lineNum = 260; Sequence = NextSquence; resetButon(); break;
            case "m04": ChipaddPoint(); lineNum = 265; Sequence = NextSquence; resetButon(); break;
            case "n05": lineNum = 270; Sequence = NextSquence; resetButon(); Resetbg(); break;
            case "n01": lineNum = 275; Sequence = NextSquence; resetButon(); break;
            case "n02": lineNum = 280; Sequence = NextSquence; resetButon(); badSitution();  break;
            case "n03":ChipaddPoint(); lineNum = 285; Sequence = NextSquence; resetButon(); break;
            case "n04": ChipFlirtPoint();  lineNum = 290; Sequence = NextSquence; resetButon(); break;
            case "o05": lineNum = 295; Sequence = NextSquence; resetButon(); Resetbg(); break;
            case "o01": ChipFlirtPoint(); lineNum = 300; Sequence = NextSquence; resetButon(); break;
            case "o02": lineNum = 305; Sequence = NextSquence; resetButon(); break;
            case "o03": ChipaddPoint(); lineNum = 310; Sequence = NextSquence; resetButon(); break;
            case "o04": lineNum = 315; Sequence = NextSquence; resetButon(); badSitution(); break;
            case "p05": lineNum = 320; Sequence = NextSquence; resetButon(); Resetbg(); break;
            case "p01":  lineNum = 325; Sequence = NextSquence; resetButon(); badSitution(); break;
            case "p02": lineNum = 330; Sequence = NextSquence; resetButon(); break;
            case "p03": ChipaddPoint(); lineNum = 335; Sequence = NextSquence; resetButon(); break;
            case "p04": ChipFlirtPoint(); lineNum = 340; Sequence = NextSquence; resetButon(); break;
            case "q05":  Sequence = NextSquence; resetButon(); Resetbg(); selectEndingChip();break;
            case "EndC05": StartCoroutine(Fadeinout_bg());  resetButon(); Resetbg(); break;




        }

    }


    void GameEnding()
    {

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

        totalCinPts = Cindypoint + CindySeducepoint;
        if (totalCinPts >= 3 && CindySeducepoint < 3)
        {
            lineNum = 105;
        }else if (CindySeducepoint >= 3)
        {
            StartCoroutine(LoveIntheAir());
            lineNum = 115;
        }
        else
        {
            badSitution();
            lineNum = 110;
        }
    }


    void selectEndingEaston()
    {
        totalEastPts = Eastonpoint + EastonpointSeduce;

        if (totalEastPts >= 3 && EastonpointSeduce < 3)
        {
            lineNum = 225;
        }
        else if (EastonpointSeduce >= 3)
        {
            StartCoroutine(LoveIntheAir());
            lineNum = 235;
        }
        else
        {
            badSitution();
            lineNum = 230;
        }
    }


    void selectEndingChip()
    {
        totalChipPts = ChipPoint + ChipFlirtpoint;

        if (totalChipPts >= 3 && ChipFlirtpoint < 3)
        {
            lineNum = 345;
        }
        else if (ChipFlirtpoint >= 3)
        {
            StartCoroutine(LoveIntheAir());
            lineNum = 355;
        }
        else
        {
            badSitution();
            lineNum = 350;
        }
    }


    void addCindypoint()
    {
        Cindypoint++;
        //Debug.Log(Cindypoint);
    }

    void addCindyFlirtpoint()
    {
        StartCoroutine(LoveIntheAir());
        CindySeducepoint++;
        //Debug.Log(CindySeducepoint);
    }

    void addEpoint()
    {
        Eastonpoint++;
        //Debug.Log(Cindypoint);
    }

    void addEFlirtpoint()
    {
        StartCoroutine(LoveIntheAir());
        EastonpointSeduce++;
        //Debug.Log(CindySeducepoint);
    }

    void ChipaddPoint()
    {
        ChipPoint++;
    }
    void ChipFlirtPoint()
    {
        StartCoroutine(LoveIntheAir());
        ChipFlirtpoint++;
    }

     void Resetbg()
    {
        //here we check if our love filters are on 
        if (loveMode)
        {
            StartCoroutine(LoveErased());
        }
        if (akward)
        {
            StartCoroutine(Akgone());
        }
    }

    void PlayAudioLine(int selection)
    {

        VoiceInterview.clip = voiceLine[selection];
        VoiceInterview.Play();
    }


    void badSitution()
    {
        StartCoroutine(YoudoneGoof());
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

    IEnumerator TypeText() { 
        for(int i = 0; i <= dialogue.Length; i++)
    {
            CurrentDialogue = dialogue.Substring(0, i);
            interviewerSay.text = CurrentDialogue;

            yield return new WaitForSeconds(delayTexAnimation);
    }
}

    IEnumerator LoveIntheAir()
    {
        loveMode = true;
        for (float i = 0; i <= 1; i += (Time.deltaTime) * 4)
        {
            love.color = new Color(1, 1, 1, i);
            yield return null;
        }
    }

    IEnumerator LoveErased()
    {
        loveMode = false;
        for (float i = 1; i >= 0; i -= (Time.deltaTime) * 4)
        {
            love.color = new Color(1, 1, 1, i);
            yield return null;
        }
    }


    IEnumerator Akgone()
    {
        akward = false;
        for (float i = 0.7f; i >= 0; i -= (Time.deltaTime) * 4)
        {

            bgAkward.color = new Color(1, 1, 1, i);
            faceAkward.color = new Color(1, 1, 1, i);
            yield return null;
        }
    }

    IEnumerator YoudoneGoof()
    {
        akward = true;
        for (float i = 0; i <= 0.7f; i += (Time.deltaTime) * 4)
        {

            bgAkward.color = new Color(1, 1, 1, i);
            faceAkward.color = new Color(1, 1, 1, i);
            yield return null;
        }
    }
}

