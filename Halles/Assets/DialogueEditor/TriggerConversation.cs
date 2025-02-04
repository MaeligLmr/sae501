using UnityEngine;
using DialogueEditor;
using System.Collections.Generic;

public class TriggerConversation : MonoBehaviour
{
    [SerializeField]
    private List<NPCConversation> conversation;
    [SerializeField]
    bool launchOnStart = false;

    private static Queue<NPCConversation> conversationQueue = new Queue<NPCConversation>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (launchOnStart)
        {
            foreach (NPCConversation conv in conversation)
            {
                triggerConversation(conv);
            }
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
            ;
        }
    }

    public void triggerConversation(NPCConversation conv)
    {
        if (conv != null)
        {
            ConversationManager.Instance.StartConversation(conv);
        }
    }

    public void setConversation(int value)
    {

        ConversationManager.Instance.SetInt("TimeGrabbed", value);

    }
}
