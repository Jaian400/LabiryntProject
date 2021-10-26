using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KeyColor
{
    Red,
    Blue,
    Green
}

public class Key : PickUp
{
    [SerializeField] private KeyColor keyColor;

    private void Start()
    {
        switch(keyColor)
        {
            case KeyColor.Blue:
                break;
        }
    }

    public override void Pickup()
    {
        base.Pickup();
        GameController.Instance.GetKey(keyColor);
    }
}
