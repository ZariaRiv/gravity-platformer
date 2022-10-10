using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSmall : Player
{
    // Override of Player.Start() to shrink and reduce jump height
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

        // Shrink to a smaller size
        transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        // Make jumps lower
        jumpSpeed = 5f;
    }
}
