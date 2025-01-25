using UnityEngine;
using DialogueEditor;
public class TriggerConversation : MonoBehaviour
{
    [SerializeField]
    private NPCConversation conversation;
    [SerializeField]
    bool launchOnStart = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (launchOnStart)
        {
            triggerConversation(conversation);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void triggerConversation(NPCConversation conv)
    {
        if (conv != null)
        {
            ConversationManager.Instance.StartConversation(conv);
        }
    }
}
