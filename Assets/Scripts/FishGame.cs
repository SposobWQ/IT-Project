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
        Debug.Log(isFishing);
        if (Input.GetMouseButtonDown(0) && !isFishing)
        {
            CastFishingRod();
        }

        if (isFishing)
        {
            // Двигаем рыболовное поле вверх и вниз
            fishingArea.localPosition = new Vector3(fishingArea.localPosition.x, Mathf.PingPong(Time.time * fishingAreaSpeed, fishingAreaHeight.rect.height - 40) - (fishingAreaHeight.rect.height - 40) / 2, fishingArea.localPosition.z);

            // Управляем движением крючка вверх/вниз
            hookPositionY += Input.GetAxis("Vertical") * hookSpeed * Time.deltaTime; // Вверх/вниз (клавиши W/S или стрелки)
            hookPositionY = Mathf.Clamp(hookPositionY, fishingAreaHeight.rect.yMin + 7.5f, fishingAreaHeight.rect.yMax - 7.5f); // Ограничиваем движение крючка в пределах зоны

            // Обновляем позицию крючка в UI
            hookImage.transform.localPosition = new Vector3(hookImage.transform.localPosition.x, hookPositionY, 0);

            // Проверяем, находится ли крючок в пределах рыболовной зоны
            if (IsHookInFishingArea())
            {
                // Обновляем прогресс рыбалки
                fishingProgress += Time.deltaTime * 0.1f;
                resultText.value = fishingProgress;
            }
            else
            {
                // Если крючок не в зоне, можно уменьшить прогресс или завершить рыбалку
                fishingProgress -= Time.deltaTime * 0.05f; // Например, уменьшаем прогресс
                resultText.value = Mathf.Clamp(fishingProgress, 0f, 1f); // Ограничаем прогресс от 0 до 1
                if(resultText.value <= 0f) FishingFalse();
            }

            // Проверяем на успешный пойманный момент
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
    
    // Начало рыбалки
    private void CastFishingRod()
    {
        if (isFishing) return; // Если рыбалка уже идет - не делаем ничего

        canvasMiniGame.SetActive(true);
        isFishing = true; // Начинаем рыбалку
        fishingProgress = startingFishingProgress; // Обнуляем прогресс
        resultText.value = 0.1f; // Сообщаем игроку, что рыбалка началась
    }

    // Поймать рыбу
    private void CatchFish()
    {
        isFishing = false; // Заканчиваем рыбалку
        resultText.value = 1f; // Сообщаем игроку, что рыба поймана
        canvasMiniGame.SetActive(false);
        fishingMiniGameController.OnCompleteMinigame();
    }
    
    private bool IsHookInFishingArea()
    {
        // Получаем границы зоны рыбалки
        float fishingAreaMinY = fishingArea.transform.localPosition.y - 20;
        float fishingAreaMaxY = fishingArea.transform.localPosition.y + 20;

        // Проверяем, находится ли позиция крючка в пределах по вертикали
        return hookPositionY >= fishingAreaMinY && hookPositionY <= fishingAreaMaxY;
    }
}