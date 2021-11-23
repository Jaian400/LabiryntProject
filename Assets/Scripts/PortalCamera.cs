using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    [SerializeField] private Transform renderPlane;
    public Transform RenderPlane => renderPlane;

    [HideInInspector] public Transform otherRenderPlane;
    private Transform playerCamera;
    void Start()
    {
        playerCamera = Camera.main.transform;
        GetComponent<Camera>().fieldOfView = Camera.main.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        AdjustCameraPosition();
    }

    void AdjustCameraPosition()
    {
        Vector3 playerOffsetPortal = otherRenderPlane.InverseTransformPoint(playerCamera.position);
        playerOffsetPortal = renderPlane.TransformPoint(playerOffsetPortal);

        transform.position = RotatePointAroundPivot(playerOffsetPortal, renderPlane.position, new Vector3(0f, 180f, 0f));

        Vector3 playerOffsetDirection = otherRenderPlane.InverseTransformDirection(playerCamera.forward);
        playerOffsetDirection = renderPlane.TransformDirection(playerOffsetDirection);

        transform.rotation = Quaternion.LookRotation(playerOffsetDirection);
        transform.Rotate(new Vector3(0f, 180f, 0f), Space.World);
    }

    public Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles)
    {
        return RotatePointAroundPivot(point, pivot, Quaternion.Euler(angles));
    }

    public Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Quaternion quaternion)
    {
        return quaternion * (point - pivot) + pivot;
    }

    public void SetTexture(RenderTexture texture)
    {
        GetComponent<Camera>().targetTexture = texture;
    }
}
