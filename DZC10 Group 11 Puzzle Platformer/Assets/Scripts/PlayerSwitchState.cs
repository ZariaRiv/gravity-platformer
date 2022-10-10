using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSwitchState : Player
{
    [HideInInspector]
    public int currentDimension, numberOfDimensions;

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

        currentDimension = getCurrentDimension();
        numberOfDimensions = levelManager.getSceneDimensions();

        controller.transform.Translate(0, 1, 0);   // To increase focus
        // TODO: Add tooltips for player actions in this state (up/down to switch, shift to accept)

        Time.timeScale = 0f; // Effectively pauses the game
    }

    // Override Update() to now only support switching dimensions
    new public void Update()
    {
        // Jump to the next dimension
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentDimension < numberOfDimensions - 1)
            {
                controller.transform.Translate(0, 40, 0);
                currentDimension++;
            }
        }

        // Jump to the previous dimension
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentDimension > 0)
            {
                controller.transform.Translate(0, -40, 0);
                currentDimension--;
            }
        }

        // Accept current dimension
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            controller.transform.Translate(0, -1, 0);
            Time.timeScale = 1f;                        // Unpause the game
            stateManager.Identify(this.gameObject);     // Lets the StateManager know they are the current player
            stateManager.UpdatePlayer();                // Prompts the StateManager to handle the dimension switch
        }
    }

    int getCurrentDimension()
    {
        float position = transform.position.y;
        int dimensionIndex = 0;

        while ((position - 40) > 0)
        {
            dimensionIndex++;
            position -= 40;
        }

        return dimensionIndex;
    }
}
