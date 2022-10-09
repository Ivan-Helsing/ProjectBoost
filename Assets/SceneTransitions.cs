using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    private int currentRoom;
    private int nextRoom;

    private void Start()
    {
        currentRoom = SceneManager.GetActiveScene().buildIndex;
        nextRoom = currentRoom + 1;
    }

    public void LoadNextLevel()
    {
        if (nextRoom >= SceneManager.sceneCountInBuildSettings)
        {
            ToStartLevel();
            return;
        }
        else SceneManager.LoadSceneAsync(nextRoom);
    }

    private static void ToStartLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartLevel()
    {
        SceneManager.LoadSceneAsync(currentRoom);
    }




}
