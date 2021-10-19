using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float speedUpMultiplier = 1.25f;
    [SerializeField] private float slowDownMultiplier = 0.75f;
    [SerializeField] private float gravity = 1f;
    [SerializeField] private Transform feet;
    [SerializeField] private LayerMask GroundMask;

    private Vector3 velocity;
    private float currentSpeed = 0;
    private float currentSpeedMultiplier = 1f;
    private CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        velocity = transform.right * x + transform.forward * z;
        characterController.Move(velocity * (speed * currentSpeedMultiplier) * Time.deltaTime);
        
        if (!GroundCheck())
        {
            currentSpeed += gravity * Time.deltaTime;
        }
        else
        {
            currentSpeed = 0;
        }
        characterController.Move(Vector3.down * currentSpeed);

        //Debug.Log((speed * currentSpeedMultiplier));
    }

    private bool GroundCheck()
    {
        RaycastHit hit;

        if (Physics.Raycast(feet.position, Vector3.down, out hit, 0.2f, GroundMask))
        {
            switch (hit.collider.gameObject.tag)
            {
                case "RedFloor":
                {
                    currentSpeedMultiplier = slowDownMultiplier;
                    break;
                }

                case "GreenFloor":
                {
                    currentSpeedMultiplier = speedUpMultiplier;
                    break;
                }

                default:
                {
                    currentSpeedMultiplier = 1f;
                    break;
                }
            }

            Debug.Log("Hit: " + hit.collider.gameObject.name);
            return true;
        }
        else
        {
            return false;
        }
    }
}
