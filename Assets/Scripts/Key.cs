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

    [SerializeField] private Renderer renderer;
    [SerializeField] private Material red;
    [SerializeField] private Material green;
    [SerializeField] private Material blue;

    private void Start()
    {
        switch(keyColor)
        {
            case KeyColor.Blue:
                renderer.material = blue;
                break;
            case KeyColor.Red:
                renderer.material = red;
                break;
            case KeyColor.Green:
                renderer.material = green;
                break;
        }
    }

    public override void Pickup()
    {
        base.Pickup();
        GameController.Instance.GetKey(keyColor);
    }
}
