using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.ComponentModel.Design;

public class MenuNavigation : MonoBehaviour
{
    public static MenuNavigation Instance { get; private set; }
    public GameObject[] menus;
    public int defaultMenuIndex = 0;
    public int currentMenuIndex {  get; private set; }
    private bool isActive = true;

    private void Awake()
    {
        Instance = this;

        for (int i = 0; i < menus.Length; i++)
        {
            if (i == defaultMenuIndex)
            {
                menus[i].SetActive(true);
            }
            else
            {
                menus[i].SetActive(false);
            }
        }

        currentMenuIndex = defaultMenuIndex;

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (!isActive)
            return;

        if(Input.GetKeyDown(KeyCode.Backspace) || Input.GetKeyDown(KeyCode.Escape))
        {
            SwitchMenu(0);
        }
    }

    public void SetMenuNavigation(bool _canNavigate)
    {
        isActive = _canNavigate;
    }

    public void SetCurrentMenuIndex(int _index)
    {
        currentMenuIndex = _index;
    }

    public int GetMenuIndex(GameObject _menu)
    {
        for(int i = 0; i < menus.Length; i++)
        {
            if (menus[i] == _menu)
            {
                return i;
            }
        }

        return -1;
    }

    public void SwitchMenu(GameObject _menu)
    {
        foreach(GameObject menu in menus)
        {
            if(menu == _menu)
            {
                menu.SetActive(true);
                currentMenuIndex = GetMenuIndex(menu);
            }
            else
            {
                menu.SetActive(false);
            }
        }
    }

    public void SwitchMenu(string _name)
    {
        foreach (GameObject menu in menus)
        {
            if (menu.name == _name)
            {
                menu.SetActive(true);
                currentMenuIndex = GetMenuIndex(menu);
            }
            else
            {
                menu.SetActive(false);
            }
        }
    }

    public void SwitchMenu(int index)
    {
        currentMenuIndex = index;

        for (int i = 0; i < menus.Length; i++)
        {
            if(i == currentMenuIndex)
            {
                menus[i].SetActive(true);
            }
            else
            {
                menus[i].SetActive(false);
            }
        }
    }
}
