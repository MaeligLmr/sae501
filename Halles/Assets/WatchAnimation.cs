using UnityEngine;
using UnityEngine.Events;

public class WatchAnimation : MonoBehaviour
{
    [SerializeField] private Animation animationToWatch;
    [SerializeField] private string clipName;
    [SerializeField] private UnityEvent onAnimationComplete;
    
    private bool hasTriggered = false;
    private float startTime;
    private bool isTracking = false;

    void Update()
    {
        if (!hasTriggered && animationToWatch != null)
        {
            AnimationState animState = animationToWatch[clipName];
            if (animState == null) return;

            if (animationToWatch.isPlaying && !isTracking)
            {
                startTime = Time.time;
                isTracking = true;
            }

            if (isTracking && Time.time >= startTime + animState.length)
            {
                onAnimationComplete.Invoke();
                hasTriggered = true;
            }
        }
    }
}
