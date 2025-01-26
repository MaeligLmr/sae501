using UnityEngine;

public class ActivateCollider : MonoBehaviour
{
    [SerializeField] private Collider colliderToActivate;

    public void EnableCollider()
    {
        if (colliderToActivate != null)
            colliderToActivate.enabled = true;
    }
}
