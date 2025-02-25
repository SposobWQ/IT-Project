using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject fishUIPrefab;
    [SerializeField] public Transform fishUIContainer;
    [SerializeField] private GameObject infoPanel;
    [SerializeField] private Image icon;
    
    private Inventory inventory; 
    private MainUIData mainUIData;

    void Start()
    {
        inventory = GameObject.Find("SceneManager").GetComponent<Inventory>();

        UpdateUI();
    }
    
    public void UpdateUI()
    {
        foreach (Transform child in fishUIContainer)
        {
            Destroy(child.gameObject);
        }
        
        inventory = GameObject.Find("SceneManager").GetComponent<Inventory>();
        
        if (inventory != null)
        {
            foreach (var fish in inventory.fishInventory)
            {
                GameObject fishUI = Instantiate(fishUIPrefab, fishUIContainer);
                
                FishUIElement fishUIElement = fishUI.GetComponent<FishUIElement>();
                fishUIElement.fish = fish;
                fishUIElement.fishInfoPanel = infoPanel;
                fishUIElement.fishIcon = icon;
                fishUIElement.fishInfoText = infoPanel.transform.Find("Text").gameObject.GetComponent<TextMeshProUGUI>();
            }
        }
    }

    public Transform FishUIContainer
    {
        get => fishUIContainer;
        set => fishUIContainer = value;
    }
}