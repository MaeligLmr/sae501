using UnityEngine;

public class changeState : MonoBehaviour
{
    public bool isDisabled = false;
    public void makeDisappear()
    {
        transform.gameObject.SetActive(false);
        isDisabled = true;
    }






}
