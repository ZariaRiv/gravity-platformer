using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    int levelDimensions = 0;

    void Awake()
    {
        countDimensions();
    }

    public void countDimensions()
    {
        // Should inform the PlayerSwitchState how many dimensions this level has
    }

    public void reloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void nextLevel()
    {
        // Loads the next level
    }
}
