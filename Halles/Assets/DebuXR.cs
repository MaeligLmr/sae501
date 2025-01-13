using UnityEngine;

public class ColliderDebug : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Trigger Enter: {other.gameObject.name}");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log($"Trigger Exit: {other.gameObject.name}");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision Enter: {collision.gameObject.name}");
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log($"Collision Exit: {collision.gameObject.name}");
    }
}
