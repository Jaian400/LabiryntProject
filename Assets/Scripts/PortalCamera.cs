using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    [SerializeField] private Transform renderPlane;
    public Transform RenderPlane => renderPlane;

    [HideInInspector] public Transform otherRenderPlane;
    private Transform playerCamera;

    public float MyAngle { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        playerCamera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        AdjustCameraPosition();
    }

    void AdjustCameraPosition()
    {
        Vector3 playerOffsetPortal = playerCamera.position - otherRenderPlane.position;
        transform.position = renderPlane.position + playerOffsetPortal;

        float angularDiff = Quaternion.Angle(renderPlane.rotation, otherRenderPlane.rotation);

        Quaternion portalRotationDifference = Quaternion.AngleAxis(angularDiff, Vector3.up);
        Vector3 newCameraDirection = portalRotationDifference * playerCamera.forward;

        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
    }

    public void SetTexture(RenderTexture texture)
    {
        GetComponent<Camera>().targetTexture = texture;
    }
}
