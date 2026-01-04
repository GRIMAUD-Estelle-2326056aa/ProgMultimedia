using UnityEngine;

public class PickableMushroom : Pickable
{
    public int amount = 1;
    public AudioClip pickupSound;


    public override void PickUp(PlayerInventory inventory)
    {
        inventory.AddMushrooms(amount);
        AudioSource.PlayClipAtPoint(pickupSound, transform.position);
        Destroy(gameObject);
    }
}
