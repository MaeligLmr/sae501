using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class SnappableCheck : MonoBehaviour
{
    public List<XRSocketInteractor> socketInteractors = new List<XRSocketInteractor>();
    public GameObject ImagesCollection;
    public UnityEvent onAllObjectsCorrect;
    public UnityEvent onObjectsIncorrect;
    private Dictionary<string, string> correctMappings;

    void Start()
    {
        // Define the correct mappings (socket name -> correct object name)
        correctMappings = new Dictionary<string, string>
        {
            { "Aimant", "Marchis" },
            { "Aimant.001", "Halles église" },
            { "Aimant.002", "Halles légumes" },
            { "Aimant.003", "Halles légumes.001" },
            { "Aimant.005", "Halles centrales" },
            { "Aimant.006", "Halles Rondes" }
        };
        foreach (XRSocketInteractor socket in socketInteractors)
        {
            socket.selectEntered.AddListener(OnObjectAttached);
            socket.selectExited.AddListener(onObjectDetached);
        }
    }
    bool AreAllItemsSnapped()
    {
        foreach (var socketInteractor in socketInteractors)
        {
            if (!socketInteractor.hasSelection)
            {
                return false;
            }
        }
        return true;
    }

    void onObjectDetached(SelectExitEventArgs args)
    {
        Outline[] outlines = ImagesCollection.GetComponentsInChildren<Outline>();
        foreach (Outline outline in outlines)
        {
            outline.OutlineWidth = 0;
            outline.OutlineColor = Color.white;
        }
    }

    void OnObjectAttached(SelectEnterEventArgs args)
    {
        if (AreAllItemsSnapped())
        {
            bool allCorrect = CheckIfObjectsAreCorrect();
            if (allCorrect)
            {
                onAllObjectsCorrect?.Invoke();
            }
            else
            {
                onObjectsIncorrect?.Invoke();
            }
        }
    }
    private bool CheckIfObjectsAreCorrect()
    {
        int countCorrect = 0;
        foreach (XRSocketInteractor socket in socketInteractors)
        {
            if (socket.interactablesSelected.Count > 0)
            {
                // Get the first interactable in the list (sockets typically hold one object)
                GameObject attachedObject = socket.interactablesSelected[0].transform.gameObject;

                // Get the correct object name for this socket
                if (correctMappings.TryGetValue(socket.name, out string correctObjectName))
                {
                    if (attachedObject.name == correctObjectName)
                    {
                        attachedObject.GetComponent<Outline>().OutlineColor = Color.green;
                        attachedObject.GetComponent<Outline>().OutlineWidth = 6;
                        countCorrect++;
                        Debug.Log($"{socket.name} has the correct object ({attachedObject.name}).");
                    }
                    else
                    {
                        attachedObject.GetComponent<Outline>().OutlineColor = Color.red;
                        attachedObject.GetComponent<Outline>().OutlineWidth = 6;
                        Debug.LogWarning($"{socket.name} has the incorrect object ({attachedObject.name}). Expected: {correctObjectName}.");
                    }
                }
                else
                {
                    Debug.LogError($"No correct mapping found for socket {socket.name}.");
                }
            }
            else
            {
                Debug.LogWarning($"{socket.name} is empty, skipping correctness check.");
            }
        }
        print(countCorrect);
        print(socketInteractors.Count);
        return countCorrect == socketInteractors.Count;
    }
}
