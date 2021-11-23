using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;

    void Update()
    {
        transform.Rotate(transform.up, rotationSpeed * Time.deltaTime);
    }

    public virtual void Pickup()
    {
        Debug.Log("PickedUp: " + gameObject.name);
        Destroy(gameObject);
    }
}
