using Unity.VisualScripting;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{

    public PauseMenu pauseMenu;
    public HUD hud;


    public bool isUIDisabled {  get; private set; }

    void Start()
    {
        UpdateManager();
    }

    void Update()
    {
        if(pauseMenu.isGamePaused || isUIDisabled)
        {
            return;
        }

        if (Input.GetKeyDown(SystemManager.Instance.inputManager.pauseKeys[0]) || Input.GetKeyDown(SystemManager.Instance.inputManager.pauseKeys[1]))
        {
            pauseMenu.gameObject.SetActive(true);
        }
    }

    public void UpdateManager()
    {
        if (SystemManager.Instance.GetScene() == "Main Menu")
        {
            SystemManager.Instance.inputManager.ToggleCursor(true);
            pauseMenu.SetGamePaused(false);
            isUIDisabled = true;
            DisableUI();
        }
        else
        {
            SystemManager.Instance.inputManager.ToggleCursor(false);
            isUIDisabled = false;
            EnableUI();
        }
    }

    private void EnableUI()
    {
        hud.gameObject.SetActive(true);
    }

    private void DisableUI()
    {
        pauseMenu.gameObject.SetActive(false);
        hud.gameObject.SetActive(false);
    }
}
