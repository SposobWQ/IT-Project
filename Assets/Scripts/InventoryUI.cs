using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject fishUIPrefab;
    [SerializeField] private Transform fishUIContainer;
    [SerializeField] private GameObject infoPanel;
    [SerializeField] private Image icon;
    [SerializeField]private Inventory inventory; 
    [SerializeField]private MainUIData mainUIData;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("SceneController").GetComponent<Inventory>();
        UpdateUI();
    }
    
    public void UpdateUI()
    {
        foreach (Transform child in fishUIContainer)
        {
            Destroy(child.gameObject);
        }
        
        inventory = GameObject.FindGameObjectWithTag("SceneController").GetComponent<Inventory>();
        
        if (inventory != null)
        {
            Debug.Log(inventory.fishInventory.Count);
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