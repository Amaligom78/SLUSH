using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Persistence;

public class SaveSlotData : MonoBehaviour
{
    public TMP_Text heroNameTxt;
    public TMP_Text heroLevelTxt;
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

    public void AssignData(string _heroNameTxt, string _heroLevelTxt, string _heroReputationTxt, string _gameName)
    {
        heroNameTxt.text = string.Concat("Name: ", _heroNameTxt);
        heroLevelTxt.text = string.Concat("Level: ", _heroLevelTxt);
        reputationTxt.text = string.Concat("Repuatation: ", _heroReputationTxt);
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
