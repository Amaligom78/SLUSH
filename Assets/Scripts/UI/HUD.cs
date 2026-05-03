using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{

    public TMP_Text healthTxt;
    public TMP_Text shieldTxt;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetHealthText(int _value)
    {
        healthTxt.text = "HP: " + _value.ToString();
    }

    public void SetShieldText(int _value)
    {
        shieldTxt.text = "Shield: " + _value.ToString();
    }
}
