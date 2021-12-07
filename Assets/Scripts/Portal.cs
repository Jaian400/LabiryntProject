using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private Portal target;

    [SerializeField] private PortalCamera portalCamera;
    [SerializeField] private PortalTeleporter portalTeleporter;

    [SerializeField] private Renderer renderPlane;
    [SerializeField] private Material portalMaterial;

    [SerializeField] private KeyHole keyHole;

    private RenderTexture renderTexture;

    private void Awake()
    {
        target.portalTeleporter.reciever = portalTeleporter.transform;
        target.portalCamera.otherRenderPlane = portalCamera.RenderPlane;
        target.keyHole.otherKeyHole = keyHole;

        renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
        renderPlane.material = Instantiate(portalMaterial);
        renderPlane.material.mainTexture = renderTexture;
    }

    private void Start()
    {
        target.portalCamera.SetTexture(renderTexture);
    }
}
