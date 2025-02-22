using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject fishUIPrefab; // Префаб для отображения рыбы
    [SerializeField] private Transform fishUIContainer;
    [SerializeField] private GameObject infoPanel;
    [SerializeField] private Image icon;
    
    private Inventory inventory; // Ссылка на инвентарь
    private MainUIData mainUIData;

    void Start()
    {
        inventory = GameObject.Find("SceneManager").GetComponent<Inventory>();

        UpdateUI();
    }

    /// <summary>
    /// Обновляет UI инвентаря.
    /// </summary>
    public void UpdateUI()
    {
        // Очищаем контейнер
        foreach (Transform child in fishUIContainer)
        {
            Destroy(child.gameObject);
        }
        
        inventory = GameObject.Find("SceneManager").GetComponent<Inventory>();
        
        if (inventory != null)
        {
            foreach (var fish in inventory.fishInventory)
            {
                // Создаём элемент UI
                GameObject fishUI = Instantiate(fishUIPrefab, fishUIContainer);

                // Назначаем рыбу для элемента UI
                FishUIElement fishUIElement = fishUI.GetComponent<FishUIElement>();
                fishUIElement.fish = fish;
                fishUIElement.fishInfoPanel = infoPanel;
                fishUIElement.fishIcon = icon; // Назначьте Image для иконки
                fishUIElement.fishInfoText = infoPanel.transform.Find("Text").gameObject.GetComponent<TextMeshProUGUI>(); // Назначьте Text для информации
            }
        }
        else
        {
            Debug.LogWarning("Inventory UI is null");
        }
    }
}