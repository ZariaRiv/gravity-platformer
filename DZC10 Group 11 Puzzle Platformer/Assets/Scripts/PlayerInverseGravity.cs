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
    }

    // TODO: override Player.Move() to allow for a different jump check
    new public void Move()
    {
        // Horizontal movement
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        Vector3 velocity = direction * moveSpeed;

        // Jumping and falling
        if (controller.velocity.y == 0f)
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
}
