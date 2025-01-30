using UnityEngine;

public class changeState : MonoBehaviour
{
    public bool isDisabled = false;
    public Collider collider;
    public void makeDisappear()
    {
        transform.gameObject.SetActive(false);
        isDisabled = true;
    }
    
    public void changeMaterial(Material newMaterial)
    {
        transform.GetComponent<Renderer>().material = newMaterial;
        isDisabled = true;
        collider.enabled = false;
    }






}
