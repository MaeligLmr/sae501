using UnityEngine;
using UnityEngine.Events;

public class TimeOutEvent : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onTwentySeconds;
    
    [SerializeField]
    private UnityEvent onFortySeconds;

    private float timer = 0f;
    private bool twentySecondTriggered = false;
    private bool fortySecondTriggered = false;

    void Start()
    {
        ResetTimer();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (!twentySecondTriggered && timer >= 20f)
        {
            twentySecondTriggered = true;
            onTwentySeconds?.Invoke();
        }

        if (!fortySecondTriggered && timer >= 40f)
        {
            fortySecondTriggered = true;
            onFortySeconds?.Invoke();
        }
    }

    public void ResetTimer()
    {
        timer = 0f;
        twentySecondTriggered = false;
        fortySecondTriggered = false;
    }
}
