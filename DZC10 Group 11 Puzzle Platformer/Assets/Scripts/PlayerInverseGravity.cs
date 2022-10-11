using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInverseGravity : Player
{
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

        // Flip the player and camera
        
    }
}
