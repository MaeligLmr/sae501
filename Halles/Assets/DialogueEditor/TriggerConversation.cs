using UnityEngine;
using DialogueEditor;
using System.Collections.Generic;

public class TriggerConversation : MonoBehaviour
{
    [SerializeField]
    private NPCConversation conversation;
    [SerializeField]
    bool launchOnStart = false;

    private static Queue<NPCConversation> conversationQueue = new Queue<NPCConversation>();

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
        CheckConversationQueue();
    }

    private void CheckConversationQueue()
    {
        if (conversationQueue.Count > 0 && !ConversationManager.Instance.IsConversationActive)
        {
            NPCConversation nextConversation = conversationQueue.Dequeue();
            ConversationManager.Instance.StartConversation(nextConversation);
        }
    }

    public void triggerConversation(NPCConversation conv)
    {
        if (conv != null)
        {
            conversationQueue.Enqueue(conv);
        }
    }
}
