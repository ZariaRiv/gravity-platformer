using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    Dictionary<int, int> sceneDimensions = new Dictionary<int, int>() // <buildIndex, dimensions>
    {
        {0, 1}, // Intro scene with 1 dimension
        {1, 1}, // Lab scene with 1 dimension
        {2, 2}, // Low Gravity 1 with 2 dimensions
        {3, 2}, // Low Gravity 2 with 2 dimensions
        {4, 3}, // Small 1 with 3 dimensions
        {5, 3}, // Small 2 with 3 dimensions
        {6, 4}, // Inverse Gravity 1 with 4 dimensions
        {7, 4}, // Inverse Gravity 2 with 4 dimensions
        {8, 4}, // Demo scene with 4 dimensions
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
