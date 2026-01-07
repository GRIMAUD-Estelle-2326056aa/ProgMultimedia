using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    public float interactionDistance = 2f;
    private PlayerInventory inventory;
    private Interactable currentInteractable;

    private void Awake()
    {
        inventory = GetComponent<PlayerInventory>();
    }

    private void Update()
    {
        // Si la touche E est activé & que l'interaction est possible
        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            currentInteractable.Interact(inventory);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Récupère l'objet de la collision
        Interactable interactable = other.GetComponent<Interactable>();
        //Si c'est un objet avec lequel on intéragi, on l'enregistre
        if (interactable != null)
        {
            currentInteractable = interactable;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Interactable interactable = other.GetComponent<Interactable>();
        if (interactable != null && interactable == currentInteractable)
        {
            currentInteractable = null;
        }
    }
}
