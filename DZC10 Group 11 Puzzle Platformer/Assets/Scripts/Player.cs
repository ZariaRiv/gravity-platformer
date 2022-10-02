using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector]
    public CharacterController controller;
    public StateManager stateManager;

    // Movement variables
    public float moveSpeed = 5.0f;
    public float jumpSpeed = 10.0f;
    public float gravity = 25.0f;
    public float terminalVelocity = -10.0f;

    [System.NonSerialized]
    public float yVelocity;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        if (stateManager == null)
        {
            Debug.Log("StateManager not found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        SwitchLayer();
    }

    public virtual void Move()
    {
        // Horizontal movement
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        Vector3 velocity = direction * moveSpeed;

        // Jumping and falling
        if (controller.isGrounded == true)
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
            yVelocity -= this.gravity * Time.deltaTime;
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
    
    private void SwitchLayer() // Placeholder for testing purposes, needs a rework
    {
        // Jump to the background
        if (Input.GetKeyDown(KeyCode.E))
        {
            controller.transform.Translate(0, 0, 10);
            stateManager.Identify(this.gameObject); // Lets the StateManager know they are the current player
            stateManager.UpdatePlayer();            // Prompts the StateManager to handle the player switch
        }

        // Jump to the foreground
        if (Input.GetKeyDown(KeyCode.Q))
        {
            controller.transform.Translate(0, 0, -10);
            stateManager.Identify(this.gameObject);
            stateManager.UpdatePlayer();
        }  
    }
}
