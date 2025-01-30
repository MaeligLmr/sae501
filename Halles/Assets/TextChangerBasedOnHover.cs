using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class TextChangerBasedOnHover : MonoBehaviour
{

    public TextMeshProUGUI textMeshPro;

    public XRRayInteractor rayInteractor;
    public string chosenText = "";
    private string originalText;

    public InteractionLayerMask selectedLayerMask;

    void Start()
    {
        if (textMeshPro != null)
        {
            originalText = textMeshPro.text;
        }
    }

    void Update()
    {
        if (rayInteractor != null && rayInteractor.isHoverActive && rayInteractor.interactablesHovered.Count > 0)
        {
            var firstInteractable = rayInteractor.interactablesHovered[0];
            if (firstInteractable != null && firstInteractable.colliders.Count > 0)
            {
                XRSimpleInteractable interactable = firstInteractable.colliders[0].GetComponent<XRSimpleInteractable>();
                if (interactable != null && interactable.interactionLayers == selectedLayerMask)
                {
                    Debug.Log("Changing text to " + chosenText);
                    textMeshPro.text = chosenText;
                }
            }
        }
        else
        {
            if (textMeshPro != null)
            {
                textMeshPro.text = originalText;
            }
        }
        return;
    }
}