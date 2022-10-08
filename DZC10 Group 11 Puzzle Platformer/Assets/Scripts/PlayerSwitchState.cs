using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSwitchState : Player
{
    // Override Start() to pause the time upon creation
    new public void Start()
    {
        controller = GetComponent<CharacterController>();

        if (stateManager == null)
        {
            Debug.Log("StateManager not found!");
        }

        if (levelManager == null)
        {
            Debug.Log("LevelManager not found!");
        }

        controller.transform.Translate(0, 1, -1);   // To increase focus
        // TODO: Add tooltips for player actions in this state (up/down to switch, shift to accept)

        Time.timeScale = 0f; // Effectively pauses the game
    }

    // Override Update() to now only support switching dimensions
    new public void Update()
    {
        // Jump to the next dimension
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            controller.transform.Translate(0, 40, 0);
        }

        // Jump to the previous dimension
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            controller.transform.Translate(0, -40, 0);
        }

        // Accept current dimension
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            controller.transform.Translate(0, -1, 1);
            Time.timeScale = 1f;                        // Unpause the game
            stateManager.Identify(this.gameObject);     // Lets the StateManager know they are the current player
            stateManager.UpdatePlayer();                // Prompts the StateManager to handle the dimension switch
        }
    }
}
