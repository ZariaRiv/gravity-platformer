using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    Dictionary<int, int> sceneDimensions = new Dictionary<int, int>() // <buildIndex, dimensions>
    {
        {0, 1}, // Menu/intro scene with 1 dimension
        {1, 2}, // lowGravity1 with 2 dimensions
        {2, 2}, // lowGravity2 with 2 dimensions
    }; 

    public int getSceneDimensions()
    {
        return sceneDimensions[SceneManager.GetActiveScene().buildIndex];
    }

    public void reloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
