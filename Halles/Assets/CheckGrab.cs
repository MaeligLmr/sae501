using UnityEngine;
using PixelCrushers.DialogueSystem; // Add this line to import the namespace containing SymbolExtensions

public class CheckItemGrab : MonoBehaviour
{
    static public int howManyImageTaken = 0;

    public void incrementImageTaken()
    {
        howManyImageTaken++;
    }

    public static int getNbrImageTaken()
    {
        return (int)(double)howManyImageTaken;
    }

    void OnEnable()
    {
        Lua.RegisterFunction("GetImageTaken", this, SymbolExtensions.GetMethodInfo(() => getNbrImageTaken()));
    }

    void OnDisable()
    {
        Lua.UnregisterFunction("GetImageTaken");
    }
}