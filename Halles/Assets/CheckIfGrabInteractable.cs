using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class CheckIfSelectingGrabInteractable : MonoBehaviour
{
    private XRRayInteractor rayInteractor;
    [SerializeField]
    private UnityEvent onSelectedEvent;


    private void Awake()
    {
        rayInteractor = GetComponent<XRRayInteractor>();
        rayInteractor.selectEntered.AddListener(OnSelected);
    }
    private void OnSelected(SelectEnterEventArgs args)
    {
        if (rayInteractor.interactablesSelected.Count > 0 && 
            rayInteractor.interactablesSelected[0].colliders[0].GetComponent<XRGrabInteractable>() != null)
        {
            onSelectedEvent.Invoke();
            return;
        }
        Debug.Log("Not a grab interactable");
        return;
    }
}
