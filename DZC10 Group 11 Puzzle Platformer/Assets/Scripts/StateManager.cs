using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    // Possible player states
    public GameObject Player;
    public GameObject PlayerSwitchState;
    public GameObject PlayerLowGravity;
    public GameObject PlayerSmall;

    public GameObject CurrentPlayer;

    [HideInInspector]
    public string[] dimensions = {"default", "lowGravity", "small", "inverseGravity", "slowMotion"};

    // Allows the current version of the player to identify themself to the StateManager
    public void Identify(GameObject currentState)
    {
        CurrentPlayer = currentState;

        if (CurrentPlayer == null)
        {
            Debug.Log("No player object found!");
        }
    }

    // Places players in the state where they may switch dimensions
    public void EnterSwitchState()
    {
        Destroy(CurrentPlayer);
        Instantiate(PlayerSwitchState, CurrentPlayer.transform.position, Quaternion.identity);
    }

    // Handles the switch to a new player object
    public void UpdatePlayer()
    {
        string currentDimension = getDimension();

        switch (currentDimension)
        {
            case "default":
                Destroy(CurrentPlayer);
                Instantiate(Player, CurrentPlayer.transform.position, Quaternion.identity);
                break;

            case "lowGravity":
                Destroy(CurrentPlayer);
                Instantiate(PlayerLowGravity, CurrentPlayer.transform.position, Quaternion.identity);
                break;

            case "small":
                Destroy(CurrentPlayer);
                Instantiate(PlayerSmall, CurrentPlayer.transform.position, Quaternion.identity);
                break;

            case "inverseGravity":
                Debug.Log("inverseGravity dimension not implemented yet!");
                //Destroy(CurrentPlayer);
                //Instantiate(PlayerInverseGravity, CurrentPlayer.transform.position, Quaternion.identity);
                break;

            case "slowMotion":
                Debug.Log("slowMotion dimension not implemented yet!");
                //Destroy(CurrentPlayer);
                //Instantiate(PlayerSlowMotion, CurrentPlayer.transform.position, Quaternion.identity);
                break;

            default:
                break;
        }
    }

    // Finds the current dimension
    public string getDimension()
    {
        float position = CurrentPlayer.transform.position.y;
        int dimensionIndex = 0;

        while ((position-40) > 0)
        {
            dimensionIndex++;
            position -= 40;
        }

        return dimensions[dimensionIndex];
    }
}
