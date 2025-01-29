using System.Collections.Generic;
using UnityEngine;

public class Enable : MonoBehaviour
{
    public List<GameObject> buttons;
    public Material material;

    public void EnableButton()
    {
        foreach (var button in buttons)
        {
            button.GetComponent<BoxCollider>().enabled = true;
            button.GetComponent<Renderer>().material = material;
        }
    }
}
