using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    private bool playerIsOverlaping = false;

    private Transform player;
    [HideInInspector] public Transform reciever;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerIsOverlaping = true;
            Debug.Log("Player entered portal");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerIsOverlaping = false;
            Debug.Log("Player is out portal");
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

        if(dotProduct < 0f)
        {
            float rotationDifference = -Quaternion.Angle(transform.rotation, reciever.transform.rotation);
            rotationDifference += 180f;

            player.Rotate(Vector3.up, rotationDifference);

            Vector3 positionOffset = Quaternion.Euler(0f, rotationDifference, 0f) * portalToPlayer;
            player.position = reciever.transform.position + positionOffset;

            playerIsOverlaping = false;
        }
    }
}
