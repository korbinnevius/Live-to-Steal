using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadur : MonoBehaviour
{

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(2, LoadSceneMode.Additive);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }

}
