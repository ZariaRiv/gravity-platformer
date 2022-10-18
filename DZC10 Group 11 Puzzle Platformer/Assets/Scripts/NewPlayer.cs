using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class NewPlayer : MonoBehaviour
{
    [HideInInspector] public SpriteRenderer spriteRenderer;
    [HideInInspector] public Animator anim;
    [HideInInspector] public bool facingRight = true;
    [HideInInspector] public bool isGrounded = false;
    
    public StateManager stateManager;
    public LevelManager levelManager;

    // Movement variables
    public float moveSpeed = 5.0f;
    public float jumpSpeed = 10.0f;
    public float gravityScale = 1f;
    public float terminalVelocity = -10.0f;
    
    [System.NonSerialized] public float yVelocity;

    // Start is called before the first frame update
    public virtual void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

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
        IsGrounded();
        Move();
        SwitchDimensions();
        MenuInputs();
    }

    public virtual void IsGrounded()
    {
        
    }

    public virtual void Move()
    {
        // Horizontal movement
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 direction = new Vector2(horizontalInput, 0);
        Vector2 velocity = direction * moveSpeed;
        
        if (anim)
        {
            anim.SetFloat("speed", Mathf.Abs(moveSpeed * horizontalInput));
        }
        
        if (horizontalInput < 0 && !facingRight)
        {
			reverseImage ();
        } 
        else if (horizontalInput > 0 && facingRight)
        {
			reverseImage ();
        }

        // Jumping and falling
        if (isGrounded)
        {
            // Jump when pressing space/w/arrow up by setting vetical speed
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                yVelocity = jumpSpeed;
            }
        }

        // Apply changes to vertical speed
        velocity.y = yVelocity;

        // Apply horizontal and vertical movement changes made this frame
        transform.Translate(velocity * Time.deltaTime);
    }
    
    public virtual void SwitchDimensions()
    {
        // Enter mode to switch dimensions by pressing either Shift keys while grounded
        if (isGrounded && (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)))
        {
            print("Shift!");
            //stateManager.Identify(this.gameObject); // Lets the StateManager know they are the current player
            //stateManager.EnterSwitchState();        // Prompts the StateManager to expect a dimension switch
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

    public void reverseImage()
	{
		// Switch the value of the Boolean
		facingRight = !facingRight;

        spriteRenderer.flipX = facingRight;
 
		// Get and store the local scale of the RigidBody2D
		//Vector2 theScale = rb.transform.localScale;
 
		// Flip it around the other way
		//theScale.x *= -1;
		//rb.transform.localScale = theScale;
	}
}
