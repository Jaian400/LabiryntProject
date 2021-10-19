using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    [SerializeField] private int timeToFinish;
    private int timeLeft;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("More than one singleton");
            Debug.Break();
        }

        timeLeft = timeToFinish;

        InvokeRepeating(nameof(Stopper), 1, 1);
    }

    private void Stopper()
    {
        timeLeft--;
        Debug.Log($"Time left: {timeLeft} s");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
