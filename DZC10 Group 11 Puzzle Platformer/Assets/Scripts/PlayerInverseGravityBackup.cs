/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInverseGravity : Player
{
    new public GameObject camera;

    // Override of Player.Start() to invert gravity
    new public void Start()
    {
        controller = GetComponent<CharacterController>();

        // Checks if the current scene contains a StateManager 
        if (stateManager == null)
        {
            Debug.Log("StateManager not found!");
        }

        // Checks if the current scene contains a LevelManager
        if (levelManager == null)
        {
            Debug.Log("LevelManager not found!");
        }

        // Checks if the camera is set correctly
        if (camera == null)
        {
            Debug.Log("Camera not found!");
        }

        // Flip the player and camera
        transform.Rotate(0f, 180f, 0f);
        camera.transform.Rotate(0f, 0f, 180f);

        // Inverted gravity
        gravity = -gravity;
    }
}
*/