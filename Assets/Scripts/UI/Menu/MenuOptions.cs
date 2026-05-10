using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Persistence;

public class MenuOptions : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnClickNewGame()
    {
        SaveLoadSystem.Instance.NewGame();
    }
}
