using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{   
    // Singleton
    public static UIManager instance;
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
    // reference to the credits UI
    public GameObject creditsUI;
    // float for the time the state started
    private float TimeStartedState;
    // reference to the previous state
    private States previousState;
    // reference to the ship container
    public GameObject shipContainer;
    // reference to the Advanced Flight Controls Script
    private AdvFlightControls AdvFlightControls;
    // reference to the particle system
    public ParticleSystem spatialUIParticleSystem;
    // reference to the Tmpro HUD_Speed text
    public GameObject HUD_Speed_NonDiagetic;
    // reference to the speedlines image
    public Image speedlines;
    public AudioSource sfxAudioSource;
    public AudioSource bgmAudioSource;
    // list of audio clips
    public List<AudioClip> audioClips;
    // bgm audio clip
    public AudioClip bgm;
    // time since speed last reached maximum
    private float timeSinceSpeedMax = 0f;
    private bool speedMaxAudioPlayed = false;
    // time since speed last reached minimum
    private float timeSinceSpeedMin = 0f;
    private bool speedMinAudioPlayed = false;
    private bool isMuted = false;
    public Toggle muteToggle;
    public Slider healthSlider;
    public Slider speedSlider;
    public Slider bgmVolumeSlider;
    public Slider sfxVolumeSlider;
    public Slider progressBarSlider;
    public TextMeshProUGUI progressBarText;
    private float progress = 0f;
    
    // enum for the states
    public enum States
    {
        mainmenu = 0,
        pausemenu = 1,
        options = 2,
        gameplay = 3,
        winscreen = 4,
        losescreen = 5,
        credits = 6,
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
                // Makes the cursor visible
                Cursor.visible = true;
                // If the BGM isn't already playing, play it
                if (!bgmAudioSource.isPlaying)
                {
                    bgmAudioSource.PlayOneShot(bgm);
                }
                break;
            case States.pausemenu:
                //Debug.Log("I am paused.");   
                pauseMenuUI.SetActive(true);  
                // stops game time
                Time.timeScale = 0f;
                // Makes the cursor visible
                Cursor.visible = true;
                // Pause the BGM & SFX
                bgmAudioSource.Pause();
                sfxAudioSource.Pause();
                break;
            case States.options:
                //Debug.Log("I am options.");
                optionsMenuUI.SetActive(true); 
                // stops game time
                Time.timeScale = 0f;  
                // Makes the cursor visible
                Cursor.visible = true;
                // Pause the BGM
                bgmAudioSource.Pause();
                sfxAudioSource.Pause();
                break;
            case States.gameplay:
                //Debug.Log("I am gameplay.");
                gameplayUI.SetActive(true);   
                // Makes the cursor invisible
                Cursor.visible = false;
                break;
            case States.winscreen:
                //Debug.Log("I am winscreen."); 
                winScreenUI.SetActive(true);  
                // stops game time
                Time.timeScale = 0f;  
                // Makes the cursor visible
                Cursor.visible = true;  
                break;
            case States.losescreen:
                //Debug.Log("I am losescreen.");   
                loseScreenUI.SetActive(true);  
                // stops game time
                Time.timeScale = 0f;
                // Makes the cursor visible
                Cursor.visible = true;
                break;
            case States.credits:
                //Debug.Log("I am credits.");   
                creditsUI.SetActive(true);  
                // Makes the cursor visible
                Cursor.visible = true;
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
                // Sets the previous state variable to this state
                previousState = States.mainmenu;
                break;
            case States.pausemenu:
                //Debug.Log("I am paused."); 
                pauseMenuUI.SetActive(false);  
                // starts game time
                Time.timeScale = 1f;
                // Sets the previous state variable to this state
                previousState = States.pausemenu;    
                // Unpause the BGM
                bgmAudioSource.UnPause();  
                sfxAudioSource.UnPause();      
                break;
            case States.options:
                //Debug.Log("I am options."); 
                optionsMenuUI.SetActive(false); 
                // starts game time
                Time.timeScale = 1f; 
                // Sets the previous state variable to this state
                previousState = States.options; 
                // Unpause the BGM
                bgmAudioSource.UnPause(); 
                sfxAudioSource.UnPause();           
                break;
            case States.gameplay:
                //Debug.Log("I am gameplay.");
                gameplayUI.SetActive(false);    
                // Sets the previous state variable to this state
                previousState = States.gameplay;  
                // Makes the cursor visible
                Cursor.visible = true;              
                break;
            case States.winscreen:
                //Debug.Log("I am winscreen.");
                winScreenUI.SetActive(false); 
                // starts game time
                Time.timeScale = 1f;
                // Sets the previous state variable to this state
                previousState = States.winscreen;               
                break;
            case States.losescreen:
                //Debug.Log("I am losescreen.");
                loseScreenUI.SetActive(false); 
                // starts game time
                Time.timeScale = 1f;
                // Sets the previous state variable to this state
                previousState = States.losescreen;             
                break;
            case States.credits:
                //Debug.Log("I am credits.");
                creditsUI.SetActive(false); 
                // Sets the previous state variable to this state
                previousState = States.credits;             
                break;
        }
    }

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
            // Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a UIManager
            Destroy(gameObject);
        }
        // Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
        // Sets all UI to false
        SetAllUIToFalse();
        // Set the progress bar to 0
        progressBarSlider.value = 0;
        // Set the progress bar text to 0
        progressBarText.text = "0%";
        
    }
    void Start()
    {
        // Sets the current state to the default state
        OnStartedState(currentState);
    }

    void Update()
    {        
        // If the current state is gameplay...
        if (currentState == States.gameplay)
        {
            if (shipContainer == null)
            {
                Debug.Log("Ship Container not found.");
                // get the ship container
                shipContainer = GameObject.Find("Ship Container");
                if (shipContainer != null)
                {
                    Debug.Log("Ship Container found.");
                    // get the AdvFlightControls script
                    AdvFlightControls = shipContainer.GetComponent<AdvFlightControls>();
                    // get the particle system
                    spatialUIParticleSystem = shipContainer.GetComponentInChildren<ParticleSystem>();
                    // set the reference to the health slider
                    healthSlider = shipContainer.GetComponentInChildren<Slider>();
                    // set the slider to the max value
                    healthSlider.value = healthSlider.maxValue;
                    if (AdvFlightControls != null)
                    {
                        Debug.Log("AdvFlightControls found.");
                    }
                    if (spatialUIParticleSystem != null)
                    {
                        Debug.Log("Trail Particle System found.");
                    }
                }
            }
            else
            {
                // update the HUD_Speed_NonDiagetic text
                HUD_Speed_NonDiagetic.GetComponent<TextMeshProUGUI>().text = "Speed: " + AdvFlightControls.getSpeed() + " m/s";
                // adjust the particle system emission rate based on the speed
                var emission = spatialUIParticleSystem.emission;
                emission.rateOverTime = AdvFlightControls.getSpeed();
                // adjust the particle system start speed based on the speed
                var main = spatialUIParticleSystem.main;
                main.startSpeed = AdvFlightControls.getSpeed() / 2;
                // adjust the particle lifetime based on the speed
                var lifetime = spatialUIParticleSystem.main;
                lifetime.startLifetime = AdvFlightControls.getSpeed() / 10;

                // update the HUD_Speed_Meta image alpha
                float playerSpeed = AdvFlightControls.getSpeed();
                float alpha = playerSpeed / 100;
                Color imageColor = speedlines.color;
                imageColor.a = alpha;
                speedlines.color = imageColor;

                // update the HUD_Speed_Wheel "slider" value
                speedSlider.value = AdvFlightControls.getSpeed();

                // if the speed is at the maximum...
                if (AdvFlightControls.getSpeed() > 10 && !speedMaxAudioPlayed)
                {
                    // ...increment the time since speed last reached maximum
                    timeSinceSpeedMax += Time.deltaTime;
                    // if the time since speed last reached maximum is greater than 1 second...
                    if (timeSinceSpeedMax > 1f)
                    {
                        // set the speed max audio played to true
                        speedMaxAudioPlayed = true;
                        // set the speed min audio played to false
                        speedMinAudioPlayed = false;
                        // ...play the speed max audio clip
                        sfxAudioSource.PlayOneShot(audioClips[1]);
                        // reset the time since speed last reached maximum
                        timeSinceSpeedMax = 0f;
                    }
                }
                // if the speed is at the minimum...
                else if (AdvFlightControls.getSpeed() < 5 && !speedMinAudioPlayed)
                {
                    // ...increment the time since speed last reached minimum
                    timeSinceSpeedMin += Time.deltaTime;
                    // if the time since speed last reached minimum is greater than 1 second...
                    if (timeSinceSpeedMin > 1f)
                    {
                        // set the speed min audio played to true
                        speedMinAudioPlayed = true;
                        // set the speed max audio played to false
                        speedMaxAudioPlayed = false;
                        // ...play the speed min audio clip
                        sfxAudioSource.PlayOneShot(audioClips[0]);
                        // reset the time since speed last reached minimum
                        timeSinceSpeedMin = 0f;
                    }
                }      
            }
        }     
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
        creditsUI.SetActive(false);
    }

    // This method activates the main menu UI
    public void MainMenu()
    {
        // If the current scene isn't the main menu scene...
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            // ...load the main menu scene
            SceneManager.LoadScene("MainMenu");
        }
        //Debug.Log("Main Menu clicked");
        currentState = States.mainmenu;
    }

    // This method activates the pause menu UI
    public void PauseMenu()
    {
        //Debug.Log("Pause Menu clicked");
        currentState = States.pausemenu;
    }

    // This method activates the options menu UI
    public void OptionsMenu()
    {
        //Debug.Log("Options Menu clicked");
        currentState = States.options;
    }

    // This method activates the gameplay UI
    public void GameplayUI()
    {
        //Debug.Log("Gameplay UI clicked");
        // Load the GamePlay scene
        SceneManager.LoadScene("GamePlay");
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

    // This method activates the credits UI
    public void Credits()
    {
        currentState = States.credits;
    }

    // This method returns to the state prior to the current state
    // Functions as a back/return button for the UI
    public void Return()
    {
        // if we're on the win screen or the lose screen...
        if (currentState == States.winscreen || currentState == States.losescreen)
        {
            // ...load the main menu scene
            SceneManager.LoadScene("MainMenu");
            currentState = States.mainmenu;
        }
        else if (previousState == States.mainmenu)
        {
            currentState = States.mainmenu;
        }
        else if (previousState == States.gameplay)
        {
            currentState = States.gameplay;
        }
        else if (previousState == States.pausemenu)
        {
            currentState = States.pausemenu;
        }
        else if (previousState == States.options)
        {
            // prevents an infinite loop between pause menu and options menu if you are in the Gameplay scene
            if (currentState == States.pausemenu)
            {
                currentState = States.gameplay;
            }
            else
            {
                currentState = States.options;
            }
        }        
        else if (previousState == States.credits)
        {
            currentState = States.credits;
        }
    }

    public void ToggleMute()
    {
        if (isMuted)
        {
            isMuted = false;
            sfxAudioSource.mute = false;
            bgmAudioSource.mute = false;
        }
        else
        {
            isMuted = true;
            sfxAudioSource.mute = true;
            bgmAudioSource.mute = true;
        }
    }

    public void AdjustBGMVolume()
    {
        bgmAudioSource.volume = bgmVolumeSlider.value;
    }

    public void AdjustSFXVolume()
    {
        sfxAudioSource.volume = sfxVolumeSlider.value;
    }

    public void IncreaseHealth()
    {
        Debug.Log("Increase health");
        healthSlider.value += 10;
        Debug.Log(healthSlider.value);
    }
    public void DecreaseHealth()
    {
        Debug.Log("Decrease health");
        healthSlider.value -= 10;
        Debug.Log(healthSlider.value);
    }

    // Update the progress bar and text
    public void UpdateProgressBar(float increaseToProgress)
    {
        progress += increaseToProgress;
        progressBarSlider.value = progress;
        progressBarText.text = progress.ToString("0") + "%";
    }

    // This method can be used to test if a certain time has elapsed since we registered an event time. 
    public bool TimeElapsedSince(float timeEventHappened, float testingTimeElapsed) => !(timeEventHappened + testingTimeElapsed > Time.time);
}