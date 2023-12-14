using System.Collections;
using System.Collections.Generic;
using TiltFive;
using UnityEngine;
using UnityEngine.SceneManagement;
using Input = UnityEngine.Input;

public class RestartGame : MonoBehaviour
{
    public TiltFive.Input.WandButton interactButton;
    void Update()
     {
         if (TiltFive.Input.GetButtonDown(interactButton) || Input.GetKeyDown(KeyCode.R))
         {
             SceneManager.LoadScene(SceneManager.GetActiveScene().name);
         }
            
                 
             
             
         
     }
    
}
