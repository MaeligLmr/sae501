using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class LaunchOnce : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onSelectedEvent;
    private bool hasTriggered = false;


    public void launchOnce()
    {
        if (hasTriggered)
        {
            return;
        }

        onSelectedEvent.Invoke();
        hasTriggered = true;
    }
}
