using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Persistence;


public class PauseMenu : MonoBehaviour
{

    public MenuNavigation menuNav;
    public bool isGamePaused { get; private set; }

    private void OnEnable()
    {
        Time.timeScale = 0f;
        SetGamePaused(true);
        print("Game Paused");
        SystemManager.Instance.inputManager.ToggleCursor(true);
    }

    void Start()
    {
        
    }

    void Update()
    {
        if(isGamePaused)
        {
            if (Input.GetKeyDown(SystemManager.Instance.inputManager.pauseKeys[0]) || Input.GetKeyDown(SystemManager.Instance.inputManager.pauseKeys[1]))
            {
                OnClickResume();
            }
        }
    }

    public void SetGamePaused(bool _isPaused)
    {
        isGamePaused = _isPaused;
    }

    public void OnClickResume()
    {
        SetGamePaused(false);
        Time.timeScale = 1f;
        SystemManager.Instance.inputManager.ToggleCursor(false);
        gameObject.SetActive(false);
    }

    public void OnClickSaveGame()
    {
        SaveLoadSystem.Instance.SaveGame();
    }

    public void OnClickQuit()
    {
        SaveLoadSystem.Instance.SaveGame();
        Time.timeScale = 1f;
        gameObject.SetActive(false);
        SceneManager.LoadScene("Main Menu");
    }

    public void OnDisable()
    {
        menuNav.SetCurrentMenuIndex(0);
        print("Game UnPaused");
    }
}
