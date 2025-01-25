using UnityEngine;
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
    }}