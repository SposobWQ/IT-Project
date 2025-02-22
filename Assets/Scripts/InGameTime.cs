using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class InGameTime : MonoBehaviour
{
    [FormerlySerializedAs("timeScriptableObject")] [SerializeField] private PlayerData playerData;

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
        
        hour = playerData.Hour;
        minute = playerData.Minute;
        month = playerData.Month;
        day = playerData.Day;
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
        playerData.Hour = hour;
        playerData.Minute = minute;
        playerData.Month = month;
        playerData.Day = day;
    }
}