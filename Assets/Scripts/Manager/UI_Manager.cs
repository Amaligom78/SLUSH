using Unity.VisualScripting;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{

    public PauseMenu pauseMenu;

    void Start()
    {

    }

    void Update()
    {
        if(pauseMenu.isGamePaused || SystemManager.Instance.GetScene() == "Main Menu")
        {
            return;
        }

        if (Input.GetKeyDown(SystemManager.Instance.inputManager.pauseKeys[0]) || Input.GetKeyDown(SystemManager.Instance.inputManager.pauseKeys[1]))
        {
            pauseMenu.gameObject.SetActive(true);
        }
    }
}
