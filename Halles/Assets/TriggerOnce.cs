using UnityEngine;
using UnityEngine.Events;

public class TriggerOnce : MonoBehaviour
{
    private bool hasTriggered = false;

    [SerializeField]
    private UnityEvent EventToTriggerOnce;
    
    public void TriggerEvent()
    {
        if (!hasTriggered)
        {
            EventToTriggerOnce.Invoke();
            hasTriggered = true;
        }
    }
}
