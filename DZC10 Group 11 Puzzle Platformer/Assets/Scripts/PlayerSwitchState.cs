using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSwitchState : Player
{
    [HideInInspector] public int currentDimension, numberOfDimensions;

    public GameObject defaultBackground;
    public GameObject lowGravtiyBackground;
    public GameObject smallBackground;
    public GameObject invertedGravityBackground;

    // Override Start() to pause the time upon creation
    new public void Start()
    {
        controller = GetComponent<CharacterController>();

        // Code for setting children componenents
        defaultBackground = transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
        lowGravtiyBackground = transform.GetChild(0).GetChild(0).GetChild(1).gameObject;
        smallBackground = transform.GetChild(0).GetChild(0).GetChild(2).gameObject;
        invertedGravityBackground = transform.GetChild(0).GetChild(0).GetChild(3).gameObject;

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

        setBackground();

        controller.transform.Translate(0, 1, -1);   // To increase focus
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
                setBackground();
            }
        }

        // Jump to the previous dimension
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentDimension > 0)
            {
                controller.transform.Translate(0, -40, 0);
                currentDimension--;
                setBackground();
            }
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

    void setBackground()
    {
        // Set all backgrounds false
        defaultBackground.SetActive(false);
        lowGravtiyBackground.SetActive(false);
        smallBackground.SetActive(false);
        invertedGravityBackground.SetActive(false);

        switch (currentDimension)
        {
            case 0:
                defaultBackground.SetActive(true);
                break;

            case 1:
                lowGravtiyBackground.SetActive(true);
                break;

            case 2:
                smallBackground.SetActive(true);
                break;

            case 3:
                invertedGravityBackground.SetActive(true);
                break;

            default:
                defaultBackground.SetActive(true);
                break;
        }
    }
}
