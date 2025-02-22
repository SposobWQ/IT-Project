using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject UI;
    [SerializeField] private PlayerData timeScript;
    [SerializeField] private string location;
    
    private MainUIData mainUIData;
    
    public static SceneController Instance { get; private set; }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void ButtonClickPC()
    {
        mainUIData.PCUI.SetActive(!mainUIData.PCUI.activeSelf);
        mainUIData.DateObject.SetActive(!mainUIData.PCUI.activeSelf);
        Time.timeScale = mainUIData.PCUI.activeSelf ? 0 : 1;
    }

    public void ButtonClickDoor()
    {
        mainUIData.DoorUI.SetActive(!mainUIData.DoorUI.activeSelf);
        mainUIData.DateObject.SetActive(!mainUIData.DoorUI.activeSelf);
        Time.timeScale = mainUIData.DoorUI.activeSelf ? 0 : 1;
    }

    private void InitializeMainUI()
    {
        GameObject[] ui = GameObject.FindGameObjectsWithTag("MainUI");

        if (ui.Length == 0)
        {
            Instantiate(UI);
        }
        else if(ui.Length > 1)
        {
            for (int i = 1; i < ui.Length; i++)
            {
                Destroy(ui[i]);
            }
        }
        
        mainUIData = ui[0].GetComponent<MainUIData>();

        TextMeshProUGUI gametime = mainUIData.Time;
        Image dayImage = mainUIData.DayImage;
        TextMeshProUGUI date = mainUIData.Date;
        TextMeshProUGUI dialogueName = mainUIData.DialogueName; 
        TextMeshProUGUI dialogue = mainUIData.Dialogue;
        Button closeDoor = mainUIData.CloseDoorUI;
        Button closePC = mainUIData.ClosePCUI;

        Button fishing = mainUIData.FishingButton;
        Button hunting = mainUIData.FishingButton;
        
        fishing.onClick.AddListener(LoadFishingScene);
        hunting.onClick.AddListener(LoadHuntingScene);
        
        closeDoor.onClick.AddListener(ButtonClickDoor);
        closePC.onClick.AddListener(ButtonClickPC);
        
        InitializeDateAndTime(date,gametime);
    }

    private void InitializeDateAndTime(TextMeshProUGUI date, TextMeshProUGUI time)
    {
        date.text = timeScript.Month + " " + timeScript.Day;
        time.text = $"{timeScript.Hour:D2}:{timeScript.Minute:D2}";
    }

    private void LoadFishingScene()
    {
        
    }

    private void LoadHuntingScene()
    {
        
    }

    public void LoadHomeScene()
    {
        
    }
    
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log($"Сцена {scene.name} загружена!");
        location = scene.name;
        InitializeMainUI();
    }
}
