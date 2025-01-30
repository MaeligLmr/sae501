using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class ChangeSceneAfter5S : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countdownText;
    [SerializeField] private UnityEvent onCountdownEnd;
    private float countdownTime = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Initialize the countdown text
        countdownText.text = countdownTime.ToString("F1");
    }

    // Update is called once per frame
    void Update()
    {
        if (countdownTime > 0)
        {
            countdownTime -= Time.deltaTime;
            countdownText.text = Mathf.Max(countdownTime, 0).ToString("F1");

            if (countdownTime <= 0)
            {
                onCountdownEnd.Invoke();
            }
        }
    }
}
