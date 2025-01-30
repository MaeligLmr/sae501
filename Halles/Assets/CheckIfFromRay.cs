using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class CustomSelectHandler : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onSelectedEvent;
    private XRGrabInteractable grabInteractable;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(OnSelected);
    }

    private void OnDestroy()
    {
        grabInteractable.selectEntered.RemoveListener(OnSelected);
    }

    private void OnSelected(SelectEnterEventArgs args)
    {
        // Ignore if the interactor is a socket
        if (args.interactorObject is XRSocketInteractor)
        {
            return;
        }

        onSelectedEvent.Invoke();
    }
}
