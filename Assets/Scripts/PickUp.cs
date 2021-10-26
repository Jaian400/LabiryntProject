using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public virtual void Pickup()
    {
        Debug.Log("PickedUp: " + gameObject.name);
        Destroy(gameObject);
    }
}
