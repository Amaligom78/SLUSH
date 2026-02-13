using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuNavigation : MonoBehaviour
{

    public GameObject[] menus;
    public int defaultMenuIndex = 0;
    private int currentMenuIndex = 0;

    private void Awake()
    {
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
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SwitchMenu(GameObject _menu)
    {
        foreach(GameObject menu in menus)
        {
            if(menu == _menu)
            {
                menu.SetActive(true);
            }
            else
            {
                menu.SetActive(false);
            }
        }
    }
}
