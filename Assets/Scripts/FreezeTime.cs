using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeTime : PickUp
{
    [SerializeField] private float duration;

    public override void Pickup()
    {
        base.Pickup();
        GameController.Instance.FreezeTime(duration);
    }
}
