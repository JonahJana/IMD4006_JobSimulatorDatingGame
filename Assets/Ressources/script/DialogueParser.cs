using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;
using System.Linq;


public class DialogueParser : MonoBehaviour
{

    List<DialogueLine> lines;
   
    struct DialogueLine
    {
       
        public string name;
        public string content;
        public int pose;
        public string choice;
        public int value;

        public DialogueLine(string n, string c, int p,string ch, int v)
        {
            name = n;
            content = c;
            pose = p;
            choice = ch;
            value = v;
        }
    }
    public TextAsset Dialoge;
    // Start is called before the first frame update
    void Start()
    {
        string file = "Dialogue2_tester";
        
        
        file += ".txt";


        lines = new List<DialogueLine>();
        LoadDialogue (file);
        Debug.Log(file);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public string GetName(int lineNumber)
    {
        if (lineNumber < lines.Count) return lines [lineNumber].name;
        return "";
    }

    public string GetContent(int lineNumber)
    {
        if (lineNumber < lines.Count) return lines [lineNumber].content;
        return "";
    }
    public int GetPose(int lineNumber)
    {
        if (lineNumber < lines.Count) return lines [lineNumber].pose;
        return 0;
    }

    public string GetChoice(int lineNumber)
    {
        if (lineNumber < lines.Count) return lines[lineNumber].choice;
        return "";
    }

    public int GetValue(int lineNumber)
    {
        if (lineNumber < lines.Count) return lines[lineNumber].value;
        return 0;
    }

    //we are loading the file that contains all  our dialoge
    void LoadDialogue(string filename)
    {
        string file = "Assets/Ressources/" + filename;
        string line;
        StreamReader r = new StreamReader(file);

        using (r)
        {
            do
            {
                line = r.ReadLine();
                if (line != null)
                {
                    //my code here resplit the current line its reading in 5 values that we rely on for our parser
                    string[] line_values = SplitCsvLine(line);
                    //Debug.Log(line_values.Length);
                    if(line_values.Length ==5)
                    { 
                    DialogueLine line_entry = new DialogueLine(line_values[0], line_values[1], int.Parse(line_values[2]), line_values[3], int.Parse(line_values[4]));
                    lines.Add(line_entry);
                }
                }
            }
            while (line != null);
            r.Close();

        }
    }

        //code to fix the split basically its to make sure that all my values are only seperated. by the correct formula this code is originally from this post 
        //its helpfull to ignore the white space and special character for our dialogue.
        string[] SplitCsvLine(string line)
        {
            string pattern = @"
            # Match one value in valid CSV string.
            (?!\s*$)                                      # Don't match empty last value.
            \s*                                           # Strip whitespace before value.
            (?:                                           # Group for value alternatives.
            '(?<val>[^'\\]*(?:\\[\S\s][^'\\]*)*)'       # Either $1: Single quoted string,
            | ""(?<val>[^""\\]*(?:\\[\S\s][^""\\]*)*)""   # or $2: Double quoted string,
            | (?<val>[^,'""\s\\]*(?:\s+[^,'""\s\\]+)*)    # or $3: Non-comma, non-quote stuff.
            )                                             # End group of value alternatives.
            \s*                                           # Strip whitespace after value.
            (?:,|$)                                       # Field ends on comma or EOS.
            ";
            string[] values = (from Match m in Regex.Matches(line, pattern,
                RegexOptions.ExplicitCapture | RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline)
                               select m.Groups[1].Value).ToArray();
            return values;




          
        }




    
}
