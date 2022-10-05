using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    // Possible player states
    public GameObject Player;
    public GameObject PlayerSwitchState;
    public GameObject PlayerLowGravity;

    public GameObject CurrentPlayer;

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
        int dimensionID = this.getDimensionID();

        switch (dimensionID)
        {
            case 0: // Default dimension
                Destroy(CurrentPlayer);
                Instantiate(Player, CurrentPlayer.transform.position, Quaternion.identity);
                break;

            case 1: // Low gravity dimension
                Destroy(CurrentPlayer);
                Instantiate(PlayerLowGravity, CurrentPlayer.transform.position, Quaternion.identity);
                break;

            default:
                break;
        }
    }

    // Finds the number of the current layer/dimension
    public int getDimensionID() // Finds the number of the current dimension based on the z coordinate
    {
        float layer = CurrentPlayer.transform.position.z;
        if (layer > 0)
        {
            return (int)(layer / 10);
        }
        else if (CurrentPlayer.name == "PlayerShift")
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }
}
