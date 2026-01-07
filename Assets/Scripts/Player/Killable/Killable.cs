using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Killable : MonoBehaviour
{
    public UnityEvent OnDeath;

    public void Die()
    {
        Debug.Log(name + " est morte");
        OnDeath?.Invoke();
    }
}
