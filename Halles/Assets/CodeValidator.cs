using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class CodeValidator : MonoBehaviour
{
    public LetterChanger[] letterChangers; 
    public UnityEvent incorrectCodeEvenEvent;
    public UnityEvent incorrectCodeOddEvent;
    public UnityEvent correctCodeEvent;
    public string correctCode = "";


    private int countNbrFalse = 0;

    public void ValidateCode()
    {
        string currentCode = "";

        foreach (var letterChanger in letterChangers)
        {
            currentCode += letterChanger.currentLetter;
        }

        if (currentCode == correctCode)
        {
            correctCodeEvent.Invoke();
        }
        else
        {
            if(countNbrFalse % 2 == 0){
                incorrectCodeEvenEvent.Invoke();
            }else{
                incorrectCodeOddEvent.Invoke();
            }
            countNbrFalse ++;

        }
    }
}
