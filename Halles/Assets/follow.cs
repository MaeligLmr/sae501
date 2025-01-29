using UnityEngine;

public class follow : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    private Quaternion rotationToFollow;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rotationToFollow = target.rotation;        
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion targetRotation = Quaternion.Euler(0, target.rotation.eulerAngles.y, 0);
        transform.rotation = targetRotation;
    }
}
