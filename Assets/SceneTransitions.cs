using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    [SerializeField] float loadSceneDelay;

    private int currentRoom;
    private int nextRoom;

    private void Start()
    {
        currentRoom = SceneManager.GetActiveScene().buildIndex;
        nextRoom = currentRoom + 1;
    }

    public void LoadNextLevel()
    {
        StartCoroutine(ToStartLevel());
        
    }

    IEnumerator ToStartLevel()
    {
        yield return new WaitForSeconds(loadSceneDelay);

        if (nextRoom >= SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadSceneAsync(0);
        }
        else SceneManager.LoadSceneAsync(nextRoom);
        
    }

    public void RestartLevel()
    {
        StartCoroutine(RestartLevelCoroutine());
    }

    IEnumerator RestartLevelCoroutine()
    {
        yield return new WaitForSeconds(loadSceneDelay);
        SceneManager.LoadSceneAsync(currentRoom);
    }




}
