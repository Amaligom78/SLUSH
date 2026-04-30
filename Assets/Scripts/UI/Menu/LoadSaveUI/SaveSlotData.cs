using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Persistence;

public class SaveSlotData : MonoBehaviour
{
    public TMP_Text playerNameTxt;
    public TMP_Text playerLevelTxt;
    public TMP_Text reputationTxt;
    public Image saveImage;
    protected string gameName;

    public DisplaySaveSlots saveSlots;
    public SaveLoadSystem saveLoadManager;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void AssignData(string _playerNameTxt, string _playerLevelTxt, string _playerReputationTxt, string _gameName)
    {
        playerNameTxt.text = string.Concat("Name: ", _playerNameTxt);
        playerLevelTxt.text = string.Concat("Level: ", _playerLevelTxt);
        reputationTxt.text = string.Concat("Repuatation: ", _playerReputationTxt);
        //saveImage = _saveImage;
        gameName = _gameName;
    }

    public string GetSaveSlotName()
    {
        return gameName;
    }

    public void OnClickLoadSaveFile()
    {
        saveSlots.ToggleSavesInteractable(false);
        saveSlots.SaveFileOptions.gameObject.SetActive(true);
        saveSlots.SaveFileOptions.StoreSaveFileInfo(gameName);
    }
}
