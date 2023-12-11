using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Input = TiltFive.Input;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject loseText;

    [SerializeField] private GameObject winText;

    private PlayerMovement _playerMovement; // Reference variable for the player movement script.

    public UnityEvent StopTimer;

    public AudioClip _sirens;
    private AudioSource _audioSource;

    private void Start()
    {
        // The below sets both the lose and win panels as false at start and also gets the player movement script and
        // Audiosource.

        loseText.SetActive(false);
        winText.SetActive(false);
        _playerMovement = GetComponent<PlayerMovement>();
        _audioSource = GetComponent<AudioSource>();

    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Security"))
        {

            // When the play collides with any gameobject that is labelled obstacles, the lose panel will be set
            // as active, the timer will stop and the siren sounds will play.

            YouLose();
            StopTimer?.Invoke();
            _audioSource.clip = _sirens;
            _audioSource.Play();
            Debug.Log("I have made contact with an obstacle");
        }
        
        if (collision.collider.CompareTag("WinBarrier"))
        {

            // When the play collides with any gameobject that is labelled obstacles, the lose panel will be set
            // as active, the timer will stop and the siren sounds will play.

            YouWin();
            // StopTimer?.Invoke();
            // _audioSource.clip = _sirens;
            // _audioSource.Play();
            Debug.Log("You have successfully stolen the money");
        }

        if (loseText && TiltFive.Input.GetButtonDown(Input.WandButton.X))
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        // if (collision.collider.CompareTag("Exit"))
        //{

        // When the play makes their way to the exit and collides with the empty collider an the exit point,
        // the win panel will be set as active and the timer will stop.

        //     YouWin();
        //     StopTimer?.Invoke();
        //     //_audioSource.clip = _sirens;
        //     //_audioSource.Play();
        //     Debug.Log("Job Done");
        // }
        //}

        // Function that sets the lose panel as active and disable player movement.
        void YouLose()
        {
            loseText.SetActive(true);
            _playerMovement.canMove = false;
        }

        // Function that sets the win panel as active and disable player movement.

        void YouWin()
        {
            winText.SetActive(true);
            _playerMovement.canMove = false;
        }
    }
}
