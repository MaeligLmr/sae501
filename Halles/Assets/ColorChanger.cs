using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Image canvasImage;
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private Color targetColor;
    [SerializeField] private InteractionLayerMask sceneChangerLayerMask; // XR Interaction Layer Mask


    private Color originalColor;
    private string originalText;

    [SerializeField] private XRRayInteractor rayInteractor; // Reference to the XRRayInteractor

    private void Start()
    {
        originalColor = canvasImage.color;
        originalText = textMeshPro.text;
    }

    private void Update()
    {

        // Check if the ray is hovering over a valid interactable
        if (rayInteractor.hasHover)
        {
            
            XRSimpleInteractable interactable = rayInteractor.interactablesHovered[0].colliders[0].GetComponent<XRSimpleInteractable>();
            Debug.Log(interactable.interactionLayers.value);
            Debug.Log(sceneChangerLayerMask.value);

            if (interactable.interactionLayers == sceneChangerLayerMask)
            {
                textMeshPro.text = "Enigme suivante";
            }else
            {
                textMeshPro.text = originalText;
            }
            ChangeColor();
        }
        else
        {
            textMeshPro.text = originalText;
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