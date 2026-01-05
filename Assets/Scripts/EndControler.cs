using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndControler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            GameController.Instance.Win();
        }
    }
}
