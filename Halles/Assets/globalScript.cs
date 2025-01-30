using UnityEngine;
using UnityEngine.Events; // Nécessaire pour UnityEvent

public class globalScript : MonoBehaviour
{
    // UnityEvents pour les différents états
    public UnityEvent firstItemNotPicked20sec;
    public UnityEvent firstItemNotPicked40sec;
    public UnityEvent ouverturePicked;
    public UnityEvent fivePicked;
    public UnityEvent elevenPicked;
    public UnityEvent thirteenPickedNoOuverture;
    public UnityEvent finish;
    public UnityEvent firstItemPicked;

    private bool is20secChecked;
    private bool is40secChecked;

    private bool isOuverturePicked;
    private int nbrPicked;
    private int lastNbrPicked; // Ajouté pour suivre le dernier nombre d'objets ramassés
    private float timer;
    private float checkInterval; // Ajouté pour contrôler l'intervalle de vérification

    void Start()
    {
        // Initialisation des variables
        lastNbrPicked = nbrPicked; 
        timer = 0f;                
        is20secChecked = false;
        is40secChecked = false;
        checkInterval = 20f; // Initialisez avec 20 secondes
    }

    void Update()
    {
        timer += Time.deltaTime; // Augmente le timer avec le temps écoulé

        // Vérification à 20 secondes
        if (timer >= 20f && !is20secChecked)
        {
            if (nbrPicked == 0)
            {
                firstItemNotPicked20sec.Invoke(); // Invoquer l'événement
            }
            is20secChecked = true; // Marquer comme vérifié
        }

        // Vérification à 40 secondes
        if (timer >= 40f && !is40secChecked)
        {
            if (nbrPicked == 0)
            {
                firstItemNotPicked40sec.Invoke(); // Invoquer l'événement
            }
            is40secChecked = true; // Marquer comme vérifié
        }
    }

    public void onEltPicked(bool ouverture)
    {
        nbrPicked++; // Augmenter le compteur des objets ramassés
        lastNbrPicked = nbrPicked; // Mettre à jour le dernier nombre d'objets ramassés
        timer = 0f; // Réinitialiser le timer à chaque ramassage
        is20secChecked = false; // Réinitialiser les vérifications
        is40secChecked = false;

        // Invoquer les événements en fonction de l'état
        if (nbrPicked == 1)
        {
            firstItemPicked.Invoke();
        }
        if (ouverture)
        {
            isOuverturePicked = true;
            ouverturePicked.Invoke();
        }
        if (nbrPicked == 5)
        {
            fivePicked.Invoke();
        }
        if (nbrPicked == 11)
        {
            elevenPicked.Invoke();
        }
        if (ouverture && nbrPicked == 13)
        {
            thirteenPickedNoOuverture.Invoke();
        }
        if (nbrPicked == 14)
        {
            finish.Invoke();
        }
    }
}
