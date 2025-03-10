using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FishUIElement : MonoBehaviour
{
    public Button fishButton;
    public GameObject fishInfoPanel; 
    public Image fishIcon;
    public TextMeshProUGUI fishInfoText;
    public Fish fish;
    
    private SellManager sellManager;

    void Start()
    {
        fishButton.onClick.AddListener(OnFishButtonClick);
        
        Image icon = transform.Find("Icon").GetComponent<Image>();
        //Text nameText = transform.Find("NameText").GetComponent<Text>();

        icon.sprite = fish.fishData.icon;
        //nameText.text = fish.fishData.fishName;
        
        sellManager = GameObject.Find("SellPage")?.GetComponent<SellManager>();
    }

    public void OnFishButtonClick()
    {
        if (sellManager != null)
        {
            sellManager.fish = fish;
        }

        fishIcon.gameObject.SetActive(true);
        fishIcon.sprite = fish.fishData.icon;
        fishInfoText.text = $"{fish.fishData.fishName}\nВес: {fish.weight} кг\nДлина: {fish.length} см\nЦена: {fish.GetPrice()}";
        
        fishInfoPanel.SetActive(true);
    }
}