using UnityEngine;
using UnityEngine.Events;

public class LaunchOnce : MonoBehaviour
{
    [SerializeField] private UnityEvent onLaunch;
    private bool hasLaunched = false;

    public void launchOnce()
    {
        if (!hasLaunched)
        {
            onLaunch?.Invoke();
            hasLaunched = true;
        }
    }
}
