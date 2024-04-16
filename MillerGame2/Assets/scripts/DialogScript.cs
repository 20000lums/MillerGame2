using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogScript : MonoBehaviour
{
    private bool DialogOn = false;
    private List<ScriptLine> Script;
    private bool IsCooldown = false;

    public Text DialogText; 

    public float talkSpeed = 0;


    public void StartDialog(List<ScriptLine> script)
    {
        DialogOn = true;
        Script = script;
        ScriptIndex = 0;
        LineIndex = 0;
        DialogText.text = "";
    }


    private float Timer = 0;
    private int LineIndex = 0;
    private int ScriptIndex = 0;

    void FixedUpdate()
    {
        if(DialogOn)
        {
            Timer += .02f;
            if(!IsCooldown)
            {

                if(Timer > talkSpeed)
                {   
                    Timer = 0;
                    DialogText.text += Script[ScriptIndex].Dialog[LineIndex];
                    LineIndex += 1;
                    if(DialogText.text == Script[ScriptIndex].Dialog)
                    {
                        IsCooldown = true;
                        LineIndex = 0;
                    }
                }
            }
            else if(Timer > Script[ScriptIndex].WaitTime)
            {
                IsCooldown = false;
                if(Script[ScriptIndex].EndLevelAfter)
                {
                    SceneManager.LoadScene(1);
                }
                ScriptIndex += 1;
                Timer = 0;
                DialogText.text = "";
            }
            if(ScriptIndex >= Script.Count)
            {

                DialogOn = false;
                ScriptIndex = 0;
            }
        }
        
    }
}
[System.Serializable]
public class ScriptLine
{
    public string Dialog; 
    public float WaitTime;
    public bool EndLevelAfter;
    public string speaker;

    public ScriptLine(string Dialog, float WaitTime, bool EndLevelAfter, string speaker)
    {
        this.Dialog = Dialog;
        this.WaitTime = WaitTime;
        this.EndLevelAfter = EndLevelAfter;
        this.speaker = speaker;
    }

}
