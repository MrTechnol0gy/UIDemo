using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton
    public static GameManager instance;
    // Public reference to the UiManager
    public UiManager uiManager;
    // Private reference to the UiManager
    private UiManager _uiManager;
    // Public reference to the button manager
    public ButtonManager buttonManager;
    // Private reference to the button manager
    private ButtonManager _buttonManager;

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
    
}
