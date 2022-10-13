using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInverseGravity : Player
{
    // Adds inverted gravity to Player.Start()
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
        terminalVelocity = -terminalVelocity;
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.flipY = true;
    }

    public override void Move()
    {
        // Horizontal movement
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        Vector3 velocity = direction * moveSpeed;

        if (anim){
            anim.SetFloat("speed", Mathf.Abs(moveSpeed * horizontalInput));
        }
        

        if (horizontalInput < 0 && !facingRight)
			reverseImage ();
		else if (horizontalInput > 0 && facingRight)
			reverseImage ();

        // Jumping and falling
        if ((controller.collisionFlags & CollisionFlags.Above) != 0)
        {
            // Jump when pressing space/w/arrow up by setting vetical speed
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                yVelocity = jumpSpeed;
            }
        }
        else // Player is in the air
        {
            // Applying gravity
            yVelocity -= gravity * Time.deltaTime;
        }

        // Sets a maximal falling speed
        if (yVelocity >= terminalVelocity)
        {
            yVelocity = terminalVelocity;
        }

        // Apply changes to vertical speed
        velocity.y = yVelocity;

        // Apply horizontal and vertical movement changes made this frame
        controller.Move(velocity * Time.deltaTime);
    }

    public override void SwitchDimensions()
    {
        // Enter mode to switch dimensions by pressing either Shift keys while grounded
        if (((controller.collisionFlags & CollisionFlags.Above) != 0) && (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)))
        {
            stateManager.Identify(this.gameObject); // Lets the StateManager know they are the current player
            stateManager.EnterSwitchState();        // Prompts the StateManager to expect a dimension switch
        }
    }
}