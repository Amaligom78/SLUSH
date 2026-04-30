using System.Persistence;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveFileOptions : MonoBehaviour
{
    public DisplaySaveSlots saveSlots;
    public SaveLoadSystem saveLoadSystem;
    private string gameName;

    public GameObject loadDeleteGroup;
    public GameObject confirmationGroup;

    private void OnEnable()
    {
        loadDeleteGroup.SetActive(true);
        confirmationGroup.SetActive(false);
    }

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Backspace))
        {
            saveSlots.ToggleSavesInteractable(true);
            gameName = string.Empty;
            loadDeleteGroup.SetActive(false);
            confirmationGroup.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }

    public void StoreSaveFileInfo(string _gameName)
    {
        gameName = _gameName;
    }

    public void OnClickLoadSave()
    {
        loadDeleteGroup.SetActive(false);
        confirmationGroup.SetActive(false);
        saveLoadSystem.LoadGame(gameName);
    }

    public void OnClickDeleteSave()
    {
        loadDeleteGroup.SetActive(false);
        confirmationGroup.SetActive(true);
    }

    public void OnClickDeleteYes()
    {
        saveSlots.DeleteSave(gameName);
        loadDeleteGroup.SetActive(false);
        confirmationGroup.SetActive(false);
        this.gameObject.SetActive(false);
    }
    public void OnClickDeleteNo()
    {
        confirmationGroup.SetActive(false);
        loadDeleteGroup.SetActive(true);
    }

    private void OnDisable()
    {
        loadDeleteGroup.SetActive(false);
        confirmationGroup.SetActive(false);
    }
}
