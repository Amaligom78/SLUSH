using UnityEngine;

public class MenuID : MonoBehaviour
{

    public int menuID = 0;
    [HideInInspector] public GameObject menu;

    private void Awake()
    {
        menu = this.gameObject;
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
