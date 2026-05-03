using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Header("Key Inputs")]
    public KeyCode[] pauseKeys;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        
    }

    public void ToggleCursor(bool _isHidden)
    {
        if(_isHidden)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
