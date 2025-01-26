using System.Collections.Generic;
using UnityEngine;

public class ResetIfDropped : MonoBehaviour
{
    [SerializeField]
    private List<Transform> _interactables = new();

    private List<Vector3> _initialPosition = new();
    private List<Quaternion> _initialRotation = new();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (var interactable in _interactables)
        {
            _initialPosition.Add(interactable.position);
            _initialRotation.Add(interactable.rotation);
        }

    }
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < _interactables.Count; i++)
        {
            if (other.transform == _interactables[i])
            {
                _interactables[i].position = _initialPosition[i];
                _interactables[i].rotation = _initialRotation[i];
                var rb = _interactables[i].GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.linearVelocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                }
            }
        }
    }
}
