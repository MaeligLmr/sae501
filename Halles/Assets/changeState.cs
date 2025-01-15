using UnityEngine;

public class changeState : MonoBehaviour
{
    public GameObject gameObject;
    public bool isDisabled = false;
    
    void Start(){
//        originalColor = originalMaterial.color;
    }


    public void makeDisappear()
    {

        gameObject.SetActive(false);
        isDisabled = true;

    }

   




}
