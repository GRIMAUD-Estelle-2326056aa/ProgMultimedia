using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOnTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger touché par : " + other.name);

        if (!other.CompareTag("Player"))
            return;

        Killable victim = other.GetComponent<Killable>();
        if (victim !=null)
        {
            victim.Die();
        }
    }
}
