using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class PushPullInteractable : XRGrabInteractable
{
    [Header("Push/Pull Settings")]
    public float pushPullSpeed = 1.0f;  // Speed at which the object moves
    public float minDistance = 0.5f;   // Minimum distance from the controller
    public float maxDistance = .0f;   // Maximum distance from the controller
    private Transform thisTransform;
    private Transform interactorTransform;  // Reference to the interactor
    private Transform grabbedTransform;  // Reference to the grabbed object
    private InputActionProperty thumbstickAction; // Change to InputActionProperty
    private Vector2 thumbstickValue; // Add this line to store thumbstick value

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        interactorTransform = args.interactorObject.transform; // Save reference to the interactor
        grabbedTransform = args.interactableObject.transform;
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        interactorTransform = null; // Clear the reference when released
        grabbedTransform = null;
    }

    public void Start()
    {
        thisTransform = transform;
        print(transform);
    }

    protected override void Awake()
    {
        base.Awake();
        // Initialize the reference to XRI Left Hand Thumbstick
        thumbstickAction = new InputActionProperty(new InputAction("Thumbstick", InputActionType.Value, "<XRController>{LeftHand}/Primary2DAxis"));
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        thumbstickAction.action?.Enable();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        thumbstickAction.action?.Disable();
    }

    void Update()
    {
        if (interactorTransform && grabbedTransform)
        {
            // Read thumbstick value
            thumbstickValue = thumbstickAction.action.ReadValue<Vector2>();


            // Get current pose and modify it
            Pose targetPose = GetTargetPose();

            // Calculate desired position change based on thumbstick
            if (thumbstickValue.y != 0)
            {
                Vector3 moveDirection = Vector3.forward * thumbstickValue.y;
                targetPose.position += moveDirection * Time.deltaTime;

                // Update the target pose correctly
                SetTargetPose(targetPose);
            }
        }
    }
}
