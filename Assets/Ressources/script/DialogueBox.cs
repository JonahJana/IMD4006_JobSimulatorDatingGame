using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBox : MonoBehaviour
{

    DialogueParser parser;

    public string dialogue;
    int lineNum;

    public GUIStyle customStyle;

    // Start is called before the first frame update
    void Start()
    {
        dialogue = " ";
        parser = GameObject.Find("DialogueParserObj").GetComponent<DialogueParser>();
        lineNum = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
     if(Input.GetMouseButtonDown(0))
        {
            dialogue = parser.GetContent(lineNum);
            lineNum++;
        }
        
    }

     void OnGUI()
    {
        dialogue = GUI.TextField(new Rect(100, 400, 600, 200), dialogue, customStyle);
    }
}
