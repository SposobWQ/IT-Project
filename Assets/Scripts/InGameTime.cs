using TMPro;
using UnityEngine;

public class InGameTime : MonoBehaviour
{
    [SerializeField] private TimeScriptableObject timeScriptableObject;

    private TextMeshProUGUI time;
    private TextMeshProUGUI date;
    private int hour;
    private int minute;
    private string month;
    private int day;
    private float gameTime; 
    
    public float timeSpeed = 60f;

    private void Awake()
    {
        MainUIData uiData = GameObject.FindGameObjectWithTag("MainUI").GetComponent<MainUIData>();

        time = uiData.Time;
        date = uiData.Date;
        
        hour = timeScriptableObject.Hour;
        minute = timeScriptableObject.Minute;
        month = timeScriptableObject.Month;
        day = timeScriptableObject.Day;
        gameTime = (hour * 3600) + (minute * 60);
    }

    private void Update()
    {
        gameTime += Time.deltaTime * timeSpeed;
        hour = (int)(gameTime / 3600) % 24;
        minute = (int)(gameTime / 60) % 60;
        updateUITime();
    }

    private void updateUITime()
    {
        time.text = $"{hour:D2}:{minute:D2}";
    }

    public void UpdateScriptableObject()
    {
        timeScriptableObject.Hour = hour;
        timeScriptableObject.Minute = minute;
        timeScriptableObject.Month = month;
        timeScriptableObject.Day = day;
    }
}