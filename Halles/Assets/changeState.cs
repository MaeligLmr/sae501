using UnityEngine;

public class changeState : MonoBehaviour
{
    public GameObject targetGameObject;
    public bool isDisabled = false;
    
    void Start(){
//        originalColor = originalMaterial.color;
    }


    public void makeDisappear()
    {

        targetGameObject.SetActive(false);
        isDisabled = true;

    }

   




}
