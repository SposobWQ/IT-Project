using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;
using DG.Tweening;

public class InGameTime : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private float animDuration = 1f;
    
    private Image image;
    private MainUIData mainUIData;
    private TextMeshProUGUI time;
    private TextMeshProUGUI date;
    private int hour;
    private int minute;
    private string month;
    private int monthIndex;
    private int dayofWeek;
    private int day;
    private float gameTime; 
    
    public readonly List<string> monthNames = new List<string>()
    {
        "Января", "Февраля", "Марта", "Апреля", "Мая", "Июня","Июля", "Августа", "Сентября", "Октября", "Ноября", "Декабря"
    };

    public readonly List<string> DayOfWeekNames = new List<string>()
    {
        "Пн", "Вт", "Ср", "Чт", "Пт", "Сб", "Вс"
    };
    
    public float timeSpeed = 60f;
    public int MoneyAtSell;

    private void Awake()
    {
        mainUIData = GameObject.FindGameObjectWithTag("MainUI").GetComponent<MainUIData>();

        time = mainUIData.Time;
        date = mainUIData.Date;

        monthIndex = playerData.MonthIndex;
        hour = playerData.Hour;
        minute = playerData.Minute;
        month = monthNames[monthIndex];
        day = playerData.Day;
        gameTime = (hour * 3600) + (minute * 60);
        dayofWeek = playerData.DayOfWeekIndex;
        
        Time.timeScale = 1f;
    }

    private void Update()
    {
        gameTime += Time.deltaTime * timeSpeed;
        hour = (int)(gameTime / 3600) % 24;
        minute = (int)(gameTime / 60) % 60;
        
        if (hour == 23)
        {
            StartCoroutine(goingToHome());
        }

        if (day > 28)
        {
            day = 1;
            monthIndex++;
        }
        
        updateUITime();
    }

    private IEnumerator goingToHome()
    {
        image.DOFade(1f, animDuration).SetEase(Ease.Linear).OnComplete(() => Time.timeScale = 0f);
        yield return new WaitForSeconds(animDuration);
        playerData.Hour = 8;
        playerData.Minute = 0;
        playerData.MonthIndex = monthIndex + (day > 28 ? 1 : 0);
        playerData.DayOfWeekIndex = (dayofWeek + 1) > 6 ? 0 : dayofWeek + 1;
        playerData.Day = day > 28 ? 0 : day+1;
        playerData.Money += MoneyAtSell;
        MoneyAtSell = 0;
        SceneManager.LoadScene(1);
    }

    private void updateUITime()
    {
        time.text = $"{hour:D2}:{minute:D2}";
    }

    public void UpdateScriptableObject()
    {
        playerData.Hour = hour;
        playerData.Minute = minute;
        playerData.MonthIndex = monthIndex;
        playerData.Day = day;
    }

    public void SkipDay()
    {
        StartCoroutine(goingToHome());
    }
}
/*using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameDate
{
    public int day = 1;
    public int monthIndex = 0; // Индекс месяца (0-11)
    public int year = 1;

    // Список названий месяцев
    private List<string> monthNames = new List<string>
    {
        "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь",
        "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"
    };

    // Метод для увеличения даты на один день
    public void IncrementDay()
    {
        day++;
        if (day > 30) // Предположим, что в месяце 30 дней
        {
            day = 1;
            monthIndex++;
            if (monthIndex >= monthNames.Count)
            {
                monthIndex = 0;
                year++;
            }
        }
    }

    // Метод для получения названия месяца
    public string GetMonthName()
    {
        return monthNames[monthIndex];
    }

    // Метод для получения даты в виде строки
    public override string ToString()
    {
        return $"{day:D2} {GetMonthName()} {year:D4}";
    }
}*/