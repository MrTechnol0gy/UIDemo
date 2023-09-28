using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Singleton
    public static GameManager instance;

    // Awake is called before Start
    void Awake()
    {
        // Check if instance already exists
        if (instance == null)
        {
            // If not, set instance to this
            instance = this;
        }
        // If instance already exists and it's not this
        else if (instance != this)
        {
            // Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager
            Destroy(gameObject);
        }

        // Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }
    
    void Update()
    {
        // When the user presses Esc, pause the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
        // When the user presses 1, open the winscreen
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            WinGame();
        }
        // When the user presses 2, open the losescreen
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            LoseGame();
        }
    }

    // Opens the lose screen
    public void LoseGame()
    {
        UIManager.instance.currentState = UIManager.States.losescreen;
    }
    // Pauses the game
    public void PauseGame()
    {
        UIManager.instance.currentState = UIManager.States.pausemenu;
    }

    // Opens the win screen
    public void WinGame()
    {
        UIManager.instance.currentState = UIManager.States.winscreen;
    }
    
    // Quits the application
    public void QuitGame()
    {
        Application.Quit();
    }
}
