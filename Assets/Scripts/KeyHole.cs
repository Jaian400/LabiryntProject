using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHole : MonoBehaviour
{
    [SerializeField] KeyColor keyColor;
    [SerializeField] private Transform door;
    [SerializeField] private Transform doorOpenPosition;

    [SerializeField] private float openingSpeed = 1f;

    public KeyHole otherKeyHole;
    public bool animateDoors;

    private Vector3 closedPosition;
    private bool canBeOpened;
    public bool opened;
    
    private Collider keyHoleController;
    private Animator keyHoleAnimator;

    // Start is called before the first frame update
    void Start()
    {
        keyHoleController = GetComponent<Collider>();
        keyHoleAnimator = GetComponent<Animator>();
        closedPosition = door.localPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            canBeOpened = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canBeOpened = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && !opened && canBeOpened && GameController.Instance.HasKey(keyColor))
        {
            Debug.Log("Opening doors");
            keyHoleController.enabled = false;
            opened = true;
            GameController.Instance.RemoveKey(keyColor);
            keyHoleAnimator.SetTrigger("UseKey");
        }

        if(animateDoors && Vector3.Distance(door.localPosition, doorOpenPosition.localPosition) >= 0f)
        {
            door.localPosition = Vector3.MoveTowards(door.localPosition, doorOpenPosition.localPosition, openingSpeed * Time.deltaTime);
        }
    }

    public void OpenDoors()
    {
        Debug.Log("Triggering open doors");
        animateDoors = true;
        otherKeyHole.animateDoors = true;
    }
}
