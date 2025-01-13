using UnityEngine;
using TMPro;

public class CodeValidator : MonoBehaviour
{
    public LetterChanger[] letterChangers; // Array de LetterChanger
    public string correctCode; // Code correct à comparer
    public TMP_Text resultText; // TextMesh Pro pour afficher le résultat

    public void ValidateCode()
    {
        string currentCode = "";

        // Construire le code actuel à partir des LetterChanger
        foreach (var letterChanger in letterChangers)
        {
            currentCode += letterChanger.currentLetter;
        }

        // Comparer le code actuel avec le code correct
        if (currentCode == correctCode)
        {
            resultText.text = "Code Correct!";
            // Actions supplémentaires à faire en cas de succès
        }
        else
        {
            resultText.text = "Code Incorrect!";
            // Actions supplémentaires à faire en cas d'échec
        }
    }
}
