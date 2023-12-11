using System.Collections;
using System.Collections.Generic;
using TiltFive;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    void Update()
     {
         if (TiltFive.Wand.TryGetWandDevice(TiltFive.PlayerIndex.One, TiltFive.ControllerIndex.Right,
                 out TiltFive.WandDevice wandDevice))
         {
             if (wandDevice.One.wasPressedThisFrame)
             {
                 SceneManager.LoadScene(SceneManager.GetActiveScene().name);
             }
             
         }
     }
    
}
