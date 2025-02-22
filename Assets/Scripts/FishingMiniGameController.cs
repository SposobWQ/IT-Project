using System;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class FishingMiniGameController : MonoBehaviour
{
    private Inventory inventory;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("SceneController").GetComponent<Inventory>();
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
        
        Fish caughtFish = new Fish(fishData, Random.Range(1.0f, 5.0f), Random.Range(30.0f, 70.0f));
        
        inventory.AddFish(caughtFish);
        
    }
    
    private static T GetRandomEnumValue<T>() where T : Enum
    {
        Array values = Enum.GetValues(typeof(T));
        return (T)values.GetValue(UnityEngine.Random.Range(0, values.Length));
    }
}
