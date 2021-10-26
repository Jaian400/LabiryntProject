using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : PickUp
{
    [SerializeField] private int value;

    [SerializeField] private Renderer renderer;
    [SerializeField] private Material red;
    [SerializeField] private Material green;

    private void Start()
    {
        renderer.material = value < 0 ? red : green;
    }

    public override void Pickup()
    {
        base.Pickup();
        GameController.Instance.ModifyTimeLeft(value);
    }
}
