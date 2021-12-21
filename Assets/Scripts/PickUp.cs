using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private AudioClip soundClip;
    [SerializeField] private float rotationSpeed;

    private AudioSource source;

    private void Awake()
    {
        source = gameObject.AddComponent<AudioSource>();
        source.playOnAwake = false;
        source.clip = soundClip;
    }

    void Update()
    {
        transform.Rotate(transform.up, rotationSpeed * Time.deltaTime);
    }

    public virtual void Pickup()
    {
        Debug.Log("PickedUp: " + gameObject.name);

        source.PlayOneShot(soundClip);

        foreach(var renderer in GetComponentsInChildren<MeshRenderer>(true))
        {
            Destroy(renderer.gameObject);
        }

        Invoke(nameof(DestroyAfterPlayed), soundClip.length);
    }

    public void DestroyAfterPlayed()
    {
        Destroy(gameObject);
    }
}
