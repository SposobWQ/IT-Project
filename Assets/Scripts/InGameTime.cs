using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class InGameTime : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    
    private TextMeshProUGUI time;
    private TextMeshProUGUI date;
    private int hour;
    private int minute;
    private string month;
    private int monthIndex;
    private int day;
    private float gameTime; 
    private List<string> monthNames = new List<string>()
    {
        "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь","Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"
    };
    
    public float timeSpeed = 60f;

    private void Awake()
    {
        MainUIData uiData = GameObject.FindGameObjectWithTag("MainUI").GetComponent<MainUIData>();

        time = uiData.Time;
        date = uiData.Date;

        monthIndex = playerData.MonthIndex;
        hour = playerData.Hour;
        minute = playerData.Minute;
        month = monthNames[monthIndex];
        day = playerData.Day;
        gameTime = (hour * 3600) + (minute * 60);
        
        Time.timeScale = 1f;
    }

    private void Update()
    {
        gameTime += Time.deltaTime * timeSpeed;
        hour = (int)(gameTime / 3600) % 24;
        minute = (int)(gameTime / 60) % 60;
        updateUITime();
    }

    public void UpdateUIData()
    {
        date.text = monthNames[monthIndex];
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