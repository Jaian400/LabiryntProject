using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : PickUp
{
    [SerializeField] private int value;

    [SerializeField] private Renderer plusRenderer;
    [SerializeField] private Renderer minusRenderer;

    private void Start()
    {
        if(value < 0)
        {
            plusRenderer.enabled = false;
        }
        else
        {
            minusRenderer.enabled = false;
        }
    }

    public override void Pickup()
    {
        base.Pickup();
        GameController.Instance.ModifyTimeLeft(value);
    }
}
