using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
    [SerializeField]
    private Image canvasImage;
    [SerializeField]
    private Color targetColor;


    public void ChangeColor()
    {
        canvasImage.color = targetColor;
    }
}
