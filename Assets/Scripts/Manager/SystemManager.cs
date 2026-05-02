using System.Persistence;
using Systems.Persistence.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SystemManager : PersistentSingleton<SystemManager>
{
    public InputManager inputManager;
    public UI_Manager uiManager;

    public void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnSceneLoaded(Scene _scene, LoadSceneMode _mode)
    {
        if(_scene.name == "Main Menu")
        {
            uiManager.pauseMenu.SetGamePaused(false);
        }
    }

    public string GetScene()
    {
        return SceneManager.GetActiveScene().name;
    }
}
