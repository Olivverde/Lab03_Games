using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class PauseMenu : MonoBehaviour { 
    private bool isPaused;
    public GameObject pauseThing;

    private void Start()
    {
        isPaused = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            pauseUnpause();
        }
    }

    public void pauseUnpause()
    {
        Debug.Log("Estaba en pausa: " + isPaused);
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
        } else {
            Time.timeScale = 0;
            isPaused = true;
        }

        Debug.Log("Ahora está en pausa: " + isPaused);
        if(pauseThing)
            pauseThing.SetActive(isPaused);
    }

    public void restartScene()
    {
        EditorSceneManager.LoadScene(EditorSceneManager.GetActiveScene().buildIndex);
    }

    public void toMainMenu()
    {
        EditorSceneManager.LoadScene(0);
    }
}
