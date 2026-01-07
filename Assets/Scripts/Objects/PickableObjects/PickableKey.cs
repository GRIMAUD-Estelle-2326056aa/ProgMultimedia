using UnityEngine;

public class PickableKey : Pickable
{
    public AudioClip pickupSound;


    public override void PickUp(PlayerInventory inventory)
    {
        inventory.AddKeys(gameObject);
        AudioSource.PlayClipAtPoint(pickupSound, transform.position);
        Destroy(gameObject);
    }
}
