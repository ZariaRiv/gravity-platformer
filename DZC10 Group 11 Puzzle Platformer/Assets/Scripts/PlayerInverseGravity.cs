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

        // Inverts the gravity and jumps
        gravity = -gravity;
        jumpSpeed = -jumpSpeed;
        playerIsGrounded = false;
    }

    new public void checkIfGrounded()
    {
        // Should now be true when touching the ceiling, can't get it to work
    }
}
