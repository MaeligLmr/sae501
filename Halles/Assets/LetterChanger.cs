using UnityEngine;
using TMPro;


public class LetterChanger : MonoBehaviour
{
    public string[] letters;
    public string currentLetter;
    public int currentIndex;
    private TMP_Text currentDisplayer;

    public void IncrementLetter()
    {
        if (letters.Length > 0)
        {
            if (currentIndex >= (letters.Length - 1))
            {
                currentIndex = 0;
                currentLetter = letters[0];
            }
            else
            {
                currentIndex++;
                currentLetter = letters[currentIndex];
            }
            currentDisplayer.text = currentLetter;

        }
    }
    public void DecrementLetter()
    {
        if (letters.Length > 0)
        {
            // Décrémente l'index ou le remet au dernier élément si on est à 0
            if (currentIndex == 0)
            {
                currentIndex = letters.Length - 1;
            }
            else
            {
                currentIndex--;
            }
            currentLetter = letters[currentIndex];
            currentDisplayer.text = currentLetter;
        }
    }

    void Start()
    {
        currentDisplayer = gameObject.GetComponent<TMP_Text>();
        if (letters.Length > 0)
        {
            currentLetter = letters[0];
            currentIndex = 0;
            currentDisplayer.text = currentLetter;
        }

    }




}
