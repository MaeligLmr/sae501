using UnityEngine;
using DialogueEditor;

public class StartConv : MonoBehaviour
{
    public bool launchOnStart = false;

    [SerializeField]
    private NPCConversation conversation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (launchOnStart)
        {
            ConversationManager.Instance.StartConversation(conversation);
        }
    }

    public void LaunchConversation(NPCConversation conv)
    {
        ConversationManager.Instance.StartConversation(conv);
    }
}
