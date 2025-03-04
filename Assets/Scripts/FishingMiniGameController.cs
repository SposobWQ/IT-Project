using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class FishingMiniGameController : MonoBehaviour
{
    [SerializeField] private GameObject dialogueWindow;
    [SerializeField] private GameObject fineWindow;
    [SerializeField] private Button agreeButton;
    [SerializeField] private Button declineButton;
    
    private Inventory inventory;
    private Fish caughtFish;
    private PlayerData time;
    private GameObject sceneManager;

    private void Start()
    {
        sceneManager = GameObject.FindGameObjectWithTag("SceneController");
        
        inventory = sceneManager.GetComponent<Inventory>();
        time = sceneManager.GetComponent<PlayerData>();
        
        agreeButton.onClick.AddListener(OnAgreeButtonClick);
        declineButton.onClick.AddListener(OnDeclineButtonClick);
    }
    
    public void OnCompleteMinigame()
    {
        FishType randomFishType = GetRandomEnumValue<FishType>();
            
        FishData fishData = Resources.Load<FishData>($"FishData/{randomFishType}");

        if (fishData == null)
        {
            Debug.LogError($"Данные о рыбе типа {randomFishType} не найдены!");
            return;
        }
        
        caughtFish = new Fish(fishData, Random.Range(1.0f, 5.0f), Random.Range(30.0f, 70.0f));
        
        dialogueWindow.SetActive(true);
        
    }

    private void OnAgreeButtonClick()
    {
        Debug.Log($"clicked {caughtFish.fishData.fishName} {caughtFish.fishData.minMonthIndex}");
        if (caughtFish.fishData.minMonthIndex <= time.MonthIndex && caughtFish.fishData.maxMonthIndex >= time.MonthIndex)
        {
            if (caughtFish.fishData.minMonthIndex == time.MonthIndex && caughtFish.fishData.minDay >= time.Day || caughtFish.fishData.maxMonthIndex == time.MonthIndex && caughtFish.fishData.maxDay >= time.Day)
            {
                dialogueWindow.SetActive(false);
                Fine();
            }
            else if(caughtFish.fishData.minMonthIndex + 1 < time.MonthIndex && caughtFish.fishData.maxMonthIndex + 1 > time.MonthIndex)
            {
                dialogueWindow.SetActive(false);
                Fine();
            }
        }
        else
        {
            inventory.AddFish(caughtFish);
            dialogueWindow.SetActive(false);
        }
        
    }

    private void Fine()
    {
        Debug.Log("Fine");
        fineWindow.SetActive(true);
        time.Money -= caughtFish.fishData.fineCost;
        
        if (time.Money < 0)
        {
            sceneManager.GetComponent<SceneController>().Fail();
        }
    }

    private void OnDeclineButtonClick()
    {
        dialogueWindow.SetActive(false);
    }
    
    private static T GetRandomEnumValue<T>() where T : Enum
    {
        Array values = Enum.GetValues(typeof(T));
        return (T)values.GetValue(UnityEngine.Random.Range(0, values.Length));
    }
    
}
