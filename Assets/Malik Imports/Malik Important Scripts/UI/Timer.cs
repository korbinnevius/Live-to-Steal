using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public TMP_Text TimerSecondsText;
    public UnityEvent onTimerCompleted;
    public UnityEvent TimerStoppedSoPlayerMovementStops;
    
    
 //   private PlayerMovement _playerMovement;
    

    
    private void Start()
    {
        timerIsRunning = true;
       // _playerMovement = GetComponent<PlayerMovement>();                           

    }
    void Update()
    {
        if (timeRemaining > 0)
        {
            // If there is still time left on the timer, keep counting down.
            
            timeRemaining -= Time.deltaTime;
        }
        

        else
        {
            // If the timer is 0, stop the timer and then enable the unity events that will activate the lose panel
            // and stop player movement.
            
            timerIsRunning = false;
            timeRemaining = 0;
            onTimerCompleted?.Invoke();
            TimerStoppedSoPlayerMovementStops?.Invoke();
            
            

        }
        
       
        
        float sec=Mathf.FloorToInt(timeRemaining%60);
        TimerSecondsText.text="Timer: "+ sec.ToString();

        
    }

    

   
}
