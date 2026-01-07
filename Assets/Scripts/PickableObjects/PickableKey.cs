using UnityEngine;

public class PickableKey : Pickable
{
    public int amount = 1;
    public AudioClip pickupSound;


    public override void PickUp(PlayerInventory inventory)
    {
        inventory.AddKeys(amount);
        AudioSource.PlayClipAtPoint(pickupSound, transform.position);
        Destroy(gameObject);
    }
}
