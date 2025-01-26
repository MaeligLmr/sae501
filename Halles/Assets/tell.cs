using UnityEngine;

public class tell : MonoBehaviour
{
    public void firtItemPicked(){
        Debug.Log("Ho... attends... Je crois que je sens un petit courant d'air... Oui ! Ça marche, tu as fais bouger quelque chose !");
    }
    public void tellNoItemPicked20sec(){
        Debug.Log("Tu as la possibilité de bouger ou appuyer quelque chose ?");
    }
    public void tellNoItemPicked40sec(){
        Debug.Log("Dans ce genre de situation généralement c'est une maquette où tu dois pouvoir interagir avec des éléments");
    }
    public void ouverturePicked(){
        Debug.Log("Ah nous y voyons enfin quelque chose !");
    }
    public void fiveItemsPicked(){
        Debug.Log("Oh ! C'est parfait ! C'est de mieux en mieux !");
    }
    public void thirteenItemPickedNoOuverture(){
        Debug.Log("« C'est pas mal mais ça manque encore un peu de lumière");
    }
    public void finish(){
        Debug.Log("Merci en tout cas c'est vraiment mieux comme ça");
    }
    public void elevenItemPicked(){
        Debug.Log("On y est presque ! Il en reste plus que 3 !");
    }
}
