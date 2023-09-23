using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{   
    // reference to the Main Menu UI
    public GameObject mainMenuUI;
    // reference to the Pause Menu UI
    public GameObject pauseMenuUI;
    // reference to the Options Menu UI
    public GameObject optionsMenuUI;
    // reference to the Gameplay UI
    public GameObject gameplayUI;
    // reference to the Win Screen UI
    public GameObject winScreenUI;
    // reference to the Lose Screen UI
    public GameObject loseScreenUI;
    // bools for each UI
    public bool mainMenuUIActive;
    public bool pauseMenuUIActive;
    public bool optionsMenuUIActive;
    public bool gameplayUIActive;
    public bool winScreenUIActive;
    public bool loseScreenUIActive;
    // float for the time the state started
    private float TimeStartedState;
    // enum for the states
    public enum States
    {
        mainmenu = 0,
        pausemenu = 1,
        options = 2,
        gameplay = 3,
        winscreen = 4,
        losescreen = 5,
    }
    private States _currentState = States.mainmenu;       //sets the starting state    
    public States currentState 
    {
        get => _currentState;
        set {
            if (_currentState != value) 
            {
                // Calling ended state for the previous state registered.
                OnEndedState(_currentState);
                
                // Setting the new current state based on active UI
                _currentState = value;
                
                // Registering here the time we're starting the state
                TimeStartedState = Time.time;
                
                // Call the started state method for the new state.
                OnStartedState(_currentState);
            }
        }
    }
    // OnStartedState is for things that should happen when a state first begins
    public void OnStartedState(States state) 
    {
        switch (state) 
        {
            case States.mainmenu:
                //Debug.Log("I am the main menu."); 
                mainMenuUI.SetActive(true);   
                break;
            case States.pausemenu:
                //Debug.Log("I am paused.");   
                pauseMenuUI.SetActive(true);  
                break;
            case States.options:
                //Debug.Log("I am options.");
                optionsMenuUI.SetActive(true);    
                break;
            case States.gameplay:
                //Debug.Log("I am gameplay.");
                gameplayUI.SetActive(true);       
                break;
            case States.winscreen:
                //Debug.Log("I am winscreen."); 
                winScreenUI.SetActive(true);      
                break;
            case States.losescreen:
                //Debug.Log("I am losescreen.");   
                loseScreenUI.SetActive(true);  
                break;
        }
    }

    // OnEndedState is for things that should end or change when a state ends; for cleanup
    public void OnEndedState(States state) 
    {
        switch (state) 
        {
            case States.mainmenu:
                //Debug.Log("I am leaving the main menu.");
                mainMenuUI.SetActive(false);
                break;
            case States.pausemenu:
                //Debug.Log("I am paused."); 
                pauseMenuUI.SetActive(false);              
                break;
            case States.options:
                //Debug.Log("I am options."); 
                optionsMenuUI.SetActive(false);              
                break;
            case States.gameplay:
                //Debug.Log("I am gameplay.");
                gameplayUI.SetActive(false);              
                break;
            case States.winscreen:
                //Debug.Log("I am winscreen.");
                winScreenUI.SetActive(false);                
                break;
            case States.losescreen:
                //Debug.Log("I am losescreen.");
                loseScreenUI.SetActive(false);              
                break;
        }
    }

    void Awake()
    {
        // Sets all UI to false
        SetAllUIToFalse();
    }
    void Start()
    {
        // Sets the current state to the default state
        OnStartedState(currentState);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Sets all Ui elements to inactive
    public void SetAllUIToFalse()
    {
        mainMenuUI.SetActive(false);
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        gameplayUI.SetActive(false);
        winScreenUI.SetActive(false);
        loseScreenUI.SetActive(false);
    }

    // This method activates the main menu UI
    public void MainMenu()
    {
        Debug.Log("Main Menu clicked");
        currentState = States.mainmenu;
    }

    // This method activates the pause menu UI
    public void PauseMenu()
    {
        Debug.Log("Pause Menu clicked");
        currentState = States.pausemenu;
    }

    // This method activates the options menu UI
    public void OptionsMenu()
    {
        Debug.Log("Options Menu clicked");
        currentState = States.options;
    }

    // This method activates the gameplay UI
    public void GameplayUI()
    {
        Debug.Log("Gameplay UI clicked");
        currentState = States.gameplay;
    }

    // This method activates the win screen UI
    public void WinScreen()
    {
        currentState = States.winscreen;
    }

    // This method activates the lose screen UI
    public void LoseScreen()
    {
        currentState = States.losescreen;
    }


    // This method can be used to test if a certain time has elapsed since we registered an event time. 
    public bool TimeElapsedSince(float timeEventHappened, float testingTimeElapsed) => !(timeEventHappened + testingTimeElapsed > Time.time);
}