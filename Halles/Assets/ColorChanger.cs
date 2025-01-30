using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Image canvasImage;
    [SerializeField] private Color targetColor;


    private Color originalColor;

    [SerializeField] private XRRayInteractor rayInteractor; // Reference to the XRRayInteractor

    private void Start()
    {
        originalColor = canvasImage.color;
    }

    private void Update()
    {
        // Check if the ray is hovering over a valid interactable
        if (rayInteractor.hasHover)
        {
            ChangeColor();
        }
        else
        {
            ResetColor();
        }
    }

    public void ChangeColor()
    {
        canvasImage.color = targetColor;
    }

    public void ResetColor()
    {
        canvasImage.color = originalColor;
    }
}