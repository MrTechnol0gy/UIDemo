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
    private float TimeStartedState;
    public enum States
    {
        mainmenu,
        pausemenu,
        options,
        gameplay,
        winscreen,
        losescreen,
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
                
                // Setting the new current state
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
                //Debug.Log("I am default."); 
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
    // OnUpdatedState is for things that occur during the state (main actions)
    public void OnUpdatedState(States state) 
    {
        switch (state) 
        {
            case States.mainmenu:
                //Debug.Log("I am default."); 
                break;
            case States.pausemenu:
                //Debug.Log("I am paused.");                
                break;
            case States.options:
                //Debug.Log("I am options.");                
                break;
            case States.gameplay:
                //Debug.Log("I am gameplay.");                
                break;
            case States.winscreen:
                //Debug.Log("I am winscreen.");                
                break;
            case States.losescreen:
                //Debug.Log("I am losescreen.");                
                break;
        }
    }

    // OnEndedState is for things that should end or change when a state ends; for cleanup
    public void OnEndedState(States state) 
    {
        switch (state) 
        {
            case States.mainmenu:
                //Debug.Log("I am default.");
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
                .              
                break;
        }
    }
    void Start()
    {
        // Sets the current state to the default state
        OnStartedState(currentState);
    }

    // Update is called once per frame
    void Update()
    {
        OnUpdatedState(currentState);
    }

    // This method can be used to test if a certain time has elapsed since we registered an event time. 
    public bool TimeElapsedSince(float timeEventHappened, float testingTimeElapsed) => !(timeEventHappened + testingTimeElapsed > Time.time);
}