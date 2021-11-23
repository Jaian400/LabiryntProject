using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : PickUp 
{
    [SerializeField] private int points;

    public override void Pickup()
    {
        base.Pickup();
    }
}
