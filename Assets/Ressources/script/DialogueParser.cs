using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;


public class DialogueParser : MonoBehaviour
{

    List<DialogueLine> lines;

    struct DialogueLine
    {
        string name;
        string content;
        int pose; 

        public DialogueLine(string n, string c, int p)
        {
            name = n;
            content = c;
            pose = p;
        }
    } 

    // Start is called before the first frame update
    void Start()
    {
        string file = "Dialogue";
        string sceneNum = EditorApplication.currentScene;
        sceneNum = Regex.Replace(sceneNum, "[^0-9]","");
        file += sceneNum;
        file += ".txt";

        LoadDialogue (file); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
                    string[] line_values = SplitCsvLine(line);
                    DialogueLine line_entry = new DialogueLine(line_values[0], line_values[1], int.Parse(line_values[2]));
                    lines.Add(line_entry);
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
