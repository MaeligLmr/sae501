using DialogueEditor;
using UnityEngine;

public class tell : MonoBehaviour
{

    public NPCConversation conversation;


    public void Start(){
        launchNpcConversation();
    }
    private void setConversation(int value){
        
        ConversationManager.Instance.SetInt("Conversation",value);
    }
    private void launchNpcConversation(){
        ConversationManager.Instance.StartConversation(conversation);
    }
    public void firtItemPicked(){
        setConversation(1);
        launchNpcConversation();
    }
    public void tellNoItemPicked20sec(){
        setConversation(6);
        launchNpcConversation();
    }
    public void tellNoItemPicked40sec(){
        setConversation(7);
        launchNpcConversation();
    }
    public void ouverturePicked(){
        setConversation(2);
        launchNpcConversation();
    }
    public void fiveItemsPicked(){
        setConversation(3);
        launchNpcConversation();
    }
    public void thirteenItemPickedNoOuverture(){
        setConversation(5);
        launchNpcConversation();
    }
    public void finish(){
        setConversation(8);
        launchNpcConversation();
    }
    public void elevenItemPicked(){
        setConversation(4);
        launchNpcConversation();
    }
}
