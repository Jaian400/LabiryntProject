using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    [SerializeField] private int timeToFinish;
    private int timeLeft;
    private bool isPaused = false;
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

        isPaused = true;

        InvokeRepeating(nameof(Stopper), 1, 1);
    }

    private void Stopper()
    {
        timeLeft--;
        Debug.Log($"Time left: {timeLeft} s");

        if(timeLeft<=0)
        {
            TimeUp();
        }
    }

    // Update is called once per frame
    void Update()
    {
        PauseCheck();
    }

    private void PauseCheck()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                UnPause();
            }
            else
            {
                Pause();
            }
        }
    }

    private void UnPause()
    {
        isPaused = false ;
        Time.timeScale = 1;
        Debug.Log("Game resumed");
    }

    private void Pause()
    {
        isPaused = true;
        Time.timeScale = 0;
        Debug.Log("Game paused");
    }

    private void TimeUp()
    {
        CancelInvoke(nameof(Stopper));
        Debug.Log("Czas up³yn¹³");
    }
}
