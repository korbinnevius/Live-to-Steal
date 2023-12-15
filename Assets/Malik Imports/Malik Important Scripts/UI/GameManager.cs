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

            // When the play collides with any gameobject that is labelled Security, the lose panel will be set
            // as active and play the siren audio source.

            YouLose();
            StopTimer?.Invoke();
            _audioSource.clip = _sirens;
            _audioSource.Play();
            Debug.Log("I have made contact with an obstacle");
        }
        
        if (collision.collider.CompareTag("WinBarrier"))
        {

            // When the play collides with the empty gameobject that is tagged WinBarrier, the win panel will be set
            // as active.

            YouWin();
            // StopTimer?.Invoke();
            // _audioSource.clip = _sirens;
            // _audioSource.Play();
            Debug.Log("You have successfully stolen the money");
        }

        if (loseText && TiltFive.Input.GetButtonDown(Input.WandButton.X))
        {
            // If the lose text is active and the player pressed the X button on the Tilt 5 Wand, the game will restart.
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        

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
