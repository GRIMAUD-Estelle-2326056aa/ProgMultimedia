using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    [Header("Interaction settings")]
    public float radius = 1.5f;            // Rayon autour du joueur dans lequel on peut détecter un objet interactable
    public LayerMask interactableMask;     // Layer(s) autorisés pour l'interaction

    private PlayerInventory inventory;     // Référence à l'inventaire du joueur
    private Interactable current;          // L'interactable détecté actuellement (si il y en a un)

    private void Awake()
    {
        // On récupère l'inventaire présent sur le même GameObject que ce script
        inventory = GetComponent<PlayerInventory>();
    }

    private void Update()
    {
        // Détection en proximité
        // OverlapSphere -> récupère les colliders dans la shpère
        //Filtre par layer (interactableMask) pour éviter de détecter le sol/murs/etc.
        Collider[] cols = Physics.OverlapSphere(transform.position, radius, interactableMask);

        //Si on trouve au moins un collider, on prend le premier.
        if (cols.Length > 0)
        {
            // GetComponentInParent au cas où le Collider est sur un enfant
            current = cols[0].GetComponentInParent<Interactable>();
        }
        else
        {
            // Aucun objet interactable proche
            current = null;
        }

        // Si le joueur appuie sur E et qu'on a un interactable, on appelle sa méthode Interact()
        if (Input.GetKeyDown(KeyCode.E) && current != null)
        {
            current.Interact(inventory);
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Dessine la sphère de détection dans la scène (visible quand l'objet est sélectionné)
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
