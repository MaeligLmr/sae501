using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class XRRotateOnOrigin : XRBaseInteractable
{
    [SerializeField]
    private float rotationSpeed = 100f;
    
    [SerializeField]
    private float maxRotationAngle = 360f;

    private bool isGrabbed = false;
    private Vector3 initialRotation;
    private IXRSelectInteractor currentInteractor;
    private Quaternion initialInteractorRotation;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        isGrabbed = true;
        currentInteractor = args.interactorObject;
        initialRotation = transform.eulerAngles;
        initialInteractorRotation = currentInteractor.transform.rotation;
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        isGrabbed = false;
        currentInteractor = null;
    }

    public void Update()
    {
        if (isGrabbed && currentInteractor != null)
        {
            // Calculate rotation based on interactor movement
            Quaternion rotationDelta = currentInteractor.transform.rotation * Quaternion.Inverse(initialInteractorRotation);
            float rotationAmount = Mathf.DeltaAngle(0, rotationDelta.eulerAngles.y) * rotationSpeed * Time.deltaTime;

            // Apply rotation around Y axis only
            transform.Rotate(Vector3.forward, rotationAmount);

            
            // Update reference rotation
            initialInteractorRotation = currentInteractor.transform.rotation;
        }
    }
}