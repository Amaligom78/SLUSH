using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveSlotData : MonoBehaviour
{
    public TMP_Text playerNameTxt;
    public TMP_Text playerLevelTxt;
    public TMP_Text reputationTxt;
    public Image saveImage;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void AssignData(string _playerNameTxt, string _playerLevelTxt, string _playerReputationTxt)
    {
        playerNameTxt.text = string.Concat("Name: ", _playerNameTxt);
        playerLevelTxt.text = string.Concat("Level: ", _playerLevelTxt);
        reputationTxt.text = string.Concat("Repuatation: ", _playerReputationTxt);
        //saveImage = _saveImage;
    }
}
