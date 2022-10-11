using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector]
    public CharacterController controller;
    public StateManager stateManager;
    public LevelManager levelManager;

    // Movement variables
    public float moveSpeed = 5.0f;
    public float jumpSpeed = 10.0f;
    public float gravity = 25.0f;
    public float terminalVelocity = -10.0f;

    [System.NonSerialized]
    public float yVelocity;

    // Start is called before the first frame update
    public virtual void Start()
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
    }

    // Update is called once per frame
    public virtual void Update()
    {
        Move();
        SwitchDimensions();
        MenuInputs();
    }

    public virtual void Move()
    {
        // Horizontal movement
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        Vector3 velocity = direction * moveSpeed;

        // Jumping and falling
        if (controller.isGrounded)
        {
            // Jump when pressing space/w/arrow up by setting vetical speed
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                yVelocity = jumpSpeed;
            }
        }
        else // Player is in the air
        {
            // This checks if the character is not moving but still has vertical velocity
            // Without it, the player doesn't stop their jump when bumping their head
            if (controller.velocity.y == 0.0f && yVelocity > 0.0f)
            {
                yVelocity = 0f;
            }

            // Applying gravity
            yVelocity -= gravity * Time.deltaTime;
        }

        // Sets a maximal falling speed
        if (yVelocity <= terminalVelocity)
        {
            yVelocity = terminalVelocity;
        }

        // Apply changes to vertical speed
        velocity.y = yVelocity;

        // Apply horizontal and vertical movement changes made this frame
        controller.Move(velocity * Time.deltaTime);
    }
    
    public virtual void SwitchDimensions()
    {
        // Enter mode to switch dimensions by pressing either Shift keys while grounded
        if (controller.isGrounded && (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)))
        {
            stateManager.Identify(this.gameObject); // Lets the StateManager know they are the current player
            stateManager.EnterSwitchState();        // Prompts the StateManager to expect a dimension switch
        }
    }

    // Handles inputs such as reloading the level or exiting the game maybe?
    private void MenuInputs()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            levelManager.reloadLevel();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Damaging") // Player collided with something dangerous, like enemies or spikes
        {
            levelManager.reloadLevel();
        }

        if (other.tag == "Portal") // Player has reached the end of the level
        {
            levelManager.nextLevel();
        }
    }
}
