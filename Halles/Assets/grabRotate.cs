using UnityEngine;
using UnityEngine.InputSystem;

public class grabRotate : MonoBehaviour
{
    private bool isGrabbing = false;
    private Vector2 previousMousePosition;
    public float rotationSpeed = 1.0f;

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                {
                    isGrabbing = true;
                    previousMousePosition = Mouse.current.position.ReadValue();
                }
            }
        }

        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            isGrabbing = false;
        }
        if (isGrabbing)
        {
            Vector2 currentMousePosition = Mouse.current.position.ReadValue();
            Vector2 mouseDelta = currentMousePosition - previousMousePosition;
            float rotationAmount = mouseDelta.x * rotationSpeed;

            transform.Rotate(Vector3.up, -rotationAmount, Space.World);

            previousMousePosition = currentMousePosition;
        }
    }
}
