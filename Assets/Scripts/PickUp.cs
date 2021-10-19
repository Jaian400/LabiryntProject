using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    //private static List<PickUp> pickups = new List<PickUp>();
    
    // Start is called before the first frame update
    void Start()
    {
        //pickups.Add(this);
    }

    void OnDestry()
    {
        //pickups.Remove(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pickup()
    {
        Debug.Log("PickedUp: " + gameObject.name);
        Destroy(gameObject);
    }
}
