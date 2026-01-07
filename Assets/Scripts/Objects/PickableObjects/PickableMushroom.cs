using UnityEngine;

public class PickableMushroom : Pickable
{
    public AudioClip pickupSound;


    public override void PickUp(PlayerInventory inventory)
    {
        inventory.AddMushrooms(gameObject);
        AudioSource.PlayClipAtPoint(pickupSound, transform.position);
        Destroy(gameObject);
    }
}
