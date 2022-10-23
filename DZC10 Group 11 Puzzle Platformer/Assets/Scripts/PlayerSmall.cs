using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSmall : Player
{
    // Adds shrinking and reducing jump height to Player.Start()
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
        transform.localScale = new Vector3(0.4f, 0.35f, 0.4f);

        // Make jumps lower
        jumpSpeed = 7.5f;

        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();
    }
}
