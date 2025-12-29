using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killable : MonoBehaviour
{
    public void Die()
    {
        Debug.Log(name + " est morte");
    }
}
