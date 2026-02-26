using System.IO;
using System.Persistence;
using TMPro;
using Unity.VisualScripting.FullSerializer;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class DisplaySaveSlots : MonoBehaviour
{
    public GameObject[] saveSlots;
    public GameObject[] saveSlotPlacement;


    private void OnEnable()
    {
        IDataService dataService;
        dataService = new FileDataService(new JsonSerializer());

        string dataPath;
        dataPath = Application.persistentDataPath;
        dataPath = Path.Combine(dataPath, "Saves");

        if (SaveSlotUtility.CountSaves(dataPath) > 0)
        {
            string[] dataPaths = SaveSlotUtility.GetSaves(dataPath);
            int index = 0;

            foreach (var fullPath in dataPaths)
            {
                string dataName = Path.GetFileNameWithoutExtension(fullPath);
                GameData gameData = dataService.Load(dataName);

                saveSlotPlacement[index].gameObject.SetActive(false);
                saveSlots[index].gameObject.SetActive(true);
                saveSlots[index].GetComponent<SaveSlotData>().AssignData(gameData.playerData.playerName, gameData.playerData.playerLevel.ToString(),
                    gameData.playerData.playerReputation);

                index++;
            }
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnDisable()
    {
        for(int i = 0; i < saveSlots.Length; i++)
        {
            saveSlots[i].SetActive(false);
            saveSlotPlacement[i].SetActive(true);
        }
    }
}
