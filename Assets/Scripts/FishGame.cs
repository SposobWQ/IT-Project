using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FishingGame : MonoBehaviour
{
    [Header("UI Elements")]
    public Image hookImage; // Изображение крючка
    public Slider resultText; // Текст с результатом
    public RectTransform fishingArea; // Поле добавления к резульятат
    
    private bool isFishing = false; // Флаг рыбалки
    private float fishingProgress = 0.35f; // Прогресс рыбалки
    private float startingFishingProgress = 0.35f;
    [SerializeField] private float hookPositionY = -100f; // Позиция крючка по вертикали
    [SerializeField] private float hookSpeed = 10000f; // Скорость движения крючка по вертикали
    [SerializeField] private float fishingAreaSpeed = 50f; // Скорость движения рыболовной зоны
    [SerializeField] private RectTransform fishingAreaHeight; //Ограничивающая всё зона
    private FishingMiniGameController fishingMiniGameController;
    
    [SerializeField] GameObject canvasMiniGame;

    private void Start()
    {
        fishingMiniGameController = GetComponent<FishingMiniGameController>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isFishing)
        {
            CastFishingRod();
        }

        if (isFishing)
        {
            fishingArea.localPosition = new Vector3(fishingArea.localPosition.x, Mathf.PingPong(Time.time * fishingAreaSpeed, fishingAreaHeight.rect.height - 40) - (fishingAreaHeight.rect.height - 40) / 2, fishingArea.localPosition.z);
            
            hookPositionY += Input.GetAxis("Vertical") * hookSpeed * Time.deltaTime;
            hookPositionY = Mathf.Clamp(hookPositionY, fishingAreaHeight.rect.yMin + 7.5f, fishingAreaHeight.rect.yMax - 7.5f);
            
            hookImage.transform.localPosition = new Vector3(hookImage.transform.localPosition.x, hookPositionY, 0);
            
            if (IsHookInFishingArea())
            {
                fishingProgress += Time.deltaTime * 0.1f;
                resultText.value = fishingProgress;
            }
            else
            {
                fishingProgress -= Time.deltaTime * 0.05f;
                resultText.value = Mathf.Clamp(fishingProgress, 0f, 1f);
                if(resultText.value <= 0f) FishingFalse();
            }
            
            if (fishingProgress >= 1f)
            {
                CatchFish();
            }
        }
    }

    private void FishingFalse()
    {
        isFishing = false;
        fishingProgress = startingFishingProgress;
        canvasMiniGame.SetActive(false);
    }
    
    private void CastFishingRod()
    {
        if (isFishing) return;

        canvasMiniGame.SetActive(true);
        isFishing = true;
        fishingProgress = startingFishingProgress; 
        resultText.value = 0.1f;
    }

    private void CatchFish()
    {
        isFishing = false; 
        resultText.value = 1f; 
        canvasMiniGame.SetActive(false);
        fishingMiniGameController.OnCompleteMinigame();
    }
    
    private bool IsHookInFishingArea()
    {
        float fishingAreaMinY = fishingArea.transform.localPosition.y - 20;
        float fishingAreaMaxY = fishingArea.transform.localPosition.y + 20;
        
        return hookPositionY >= fishingAreaMinY && hookPositionY <= fishingAreaMaxY;
    }
}