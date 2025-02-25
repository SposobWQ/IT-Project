using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SellManager : MonoBehaviour
{
    public Fish fish;
    
    private InGameTime inGameTime;
    private Inventory inventory;
    private InventoryUI inventoryUI;
    
    [SerializeField] private GameObject fishInfoPanel; 
    [SerializeField] private Image fishIcon;
    [SerializeField] private TextMeshProUGUI fishInfoText;
    [SerializeField] private GameObject fishUIContainer;

    private void Start()
    {
        inGameTime = GameObject.Find("UI").GetComponent<InGameTime>();
        inventory = GameObject.Find("SceneManager")?.GetComponent<Inventory>();
        inventoryUI = GetComponent<InventoryUI>();
    }

    public void SellFish()
    {
        inGameTime.MoneyAtSell += fish.GetPrice();
        inventory.RemoveFish(fish);
        inventoryUI.UpdateUI();
        fishUIContainer.transform.GetChild(0)?.gameObject.GetComponent<FishUIElement>().OnFishButtonClick();
        if (fishUIContainer.transform.GetChild(0) == null)
        {
            ResetInfoPanels();
        }
    }

    private void ResetInfoPanels()
    {
        fishIcon.gameObject.SetActive(false);
        fishInfoText.text = $"";
    }
}
