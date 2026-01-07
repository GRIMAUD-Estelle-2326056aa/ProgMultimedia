using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class Pickable : MonoBehaviour
{
    // Appelée quand le joueur ramasse l'objet
    public abstract void PickUp(PlayerInventory inventory);

    private void Reset()
    {
        // Simplifie la vie : met automatiquement le collider en Trigger
        Collider col = GetComponent<Collider>();
        col.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TRIGGER TOUCHÉ");

        // On cherche l'inventaire du joueur
        PlayerInventory inv = other.GetComponent<PlayerInventory>();
        if (inv == null) return;

        // Ramassage
        PickUp(inv);
    }
}
