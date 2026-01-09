using UnityEngine;
using System.Collections.Generic;

public class InteractableTree : Interactable
{
    public List<GameObject> objects = new List<GameObject>();

    public override void Interact(PlayerInventory playerInventory)
    {
        if (playerInventory.HasKey())
        {
            if (objects.Count == 0)
            {
                Debug.Log("L'arbre est vide");
                return;
            }

            foreach (GameObject obj in objects)
            {
                playerInventory.AddObject(obj);
            }

            objects.Clear();
            Debug.Log("Objets transférés de l'arbre au joueur");   
        }
        else
        {
            Debug.Log("Vous n'avez pas la clé");

        }
        
    }
}
