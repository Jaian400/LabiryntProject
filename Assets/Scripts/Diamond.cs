using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : PickUp 
{
    [SerializeField] public int points;

    public override void Pickup()
    {
        base.Pickup();
    }
}
