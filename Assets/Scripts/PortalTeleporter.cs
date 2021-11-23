using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    [HideInInspector] public Transform reciever;

    private Transform player;
    private bool playerIsOverlaping = false;
    public float PortalAngularDiff;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsOverlaping = true;
            Debug.Log("Player entered portal");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsOverlaping = false;
            Debug.Log("Player exited portal");
        }
    }

    private void FixedUpdate()
    {
        Teleport();
    }

    private void Teleport()
    {
        if (!playerIsOverlaping) return;

        Vector3 portalToPlayer = player.position - transform.position;
        float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

        if (dotProduct < 0f)
        {
            Vector3 playerOffsetPortal = transform.InverseTransformPoint(player.position);
            playerOffsetPortal = reciever.TransformPoint(playerOffsetPortal);

            player.position = RotatePointAroundPivot(playerOffsetPortal, reciever.position, new Vector3(0f, 180f, 0f));

            Vector3 playerOffsetDirection = transform.InverseTransformDirection(player.forward);
            playerOffsetDirection = reciever.TransformDirection(playerOffsetDirection);

            player.rotation = Quaternion.LookRotation(playerOffsetDirection);
            player.Rotate(new Vector3(0f, 180f, 0f), Space.World);

            playerIsOverlaping = false;
        }
    }

    public Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles)
    {
        return RotatePointAroundPivot(point, pivot, Quaternion.Euler(angles));
    }

    public Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Quaternion quaternion)
    {
        return quaternion * (point - pivot) + pivot;
    }
}