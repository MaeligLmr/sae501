using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    public void Play(string animationName)
    {
        animator.SetBool(animationName, true);
    }

    public void Stop(string animationName)
    {
        animator.SetBool(animationName, false);
    }
}
