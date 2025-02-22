using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Inventory))]
public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject UI;
    [SerializeField] private PlayerData timeScript;
    [SerializeField] private string location;
    [SerializeField] private int hunterScene = 3;
    [SerializeField] private int fishingScene = 2;
    [SerializeField] private int homeScene = 1;
    [SerializeField] private Button pcButton;
    [SerializeField] private Button doorButton;

    public Inventory inventory {get; private set;}
    private GameObject UIObject;
    private MainUIData mainUIData;
    private InGameTime inGameTime;
    private InventoryUI inventoryUI;
    
    public static SceneController Instance { get; private set; }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
            gameObject.tag = "SceneController";
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        inventory = GetComponent<Inventory>();
    }

    public void ButtonClickPC()
    {
        mainUIData.PCUI.SetActive(!mainUIData.PCUI.activeSelf);
        mainUIData.DateObject.SetActive(!mainUIData.PCUI.activeSelf);
        Time.timeScale = mainUIData.PCUI.activeSelf ? 0 : 1;
        Debug.Log(mainUIData.PCUI.activeSelf);
    }

    public void ButtonClickDoor()
    {
        mainUIData.DoorUI.SetActive(!mainUIData.DoorUI.activeSelf);
        mainUIData.DateObject.SetActive(!mainUIData.DoorUI.activeSelf);
        Time.timeScale = mainUIData.DoorUI.activeSelf ? 0 : 1;
        Debug.Log(mainUIData.DoorUI.activeSelf);
    }

    private void InitializeMainUI()
    {
        GameObject[] ui = GameObject.FindGameObjectsWithTag("MainUI");

        if (ui.Length == 0)
        {
            UIObject = Instantiate(UI);
        }
        else if(ui.Length >= 1)
        {
            UIObject = ui[0];
            for (int i = 1; i < ui.Length; i++)
            {
                Destroy(ui[i]);
            }
        }
        
        mainUIData = UIObject.GetComponent<MainUIData>();

        TextMeshProUGUI gametime = mainUIData.Time;
        Image dayImage = mainUIData.DayImage;
        TextMeshProUGUI date = mainUIData.Date;
        TextMeshProUGUI dialogueName = mainUIData.DialogueName; 
        TextMeshProUGUI dialogue = mainUIData.Dialogue;
        Button closeDoor = mainUIData.CloseDoorUI;
        Button closePC = mainUIData.ClosePCUI;
        
        inventoryUI = mainUIData.InventoryUIObject.GetComponent<InventoryUI>();
        inventoryUI.UpdateUI();
        
        inGameTime = UIObject.GetComponent<InGameTime>();

        Button fishing = mainUIData.FishingButton;
        Button hunting = mainUIData.HuntButton;
        
        fishing.onClick.AddListener(LoadFishingScene);
        hunting.onClick.AddListener(LoadHuntingScene);
        
        closeDoor.onClick.AddListener(ButtonClickDoor);
        closePC.onClick.AddListener(ButtonClickPC);
        
        SceneData sceneData = GameObject.FindGameObjectWithTag("SceneData")?.GetComponent<SceneData>();

        if (sceneData != null)
        {
            if (sceneData.PC != null || sceneData.door != null)
            {
                pcButton = sceneData.PC;
                doorButton = sceneData.door;
                
                pcButton.onClick.AddListener(ButtonClickPC);
                doorButton.onClick.AddListener(ButtonClickDoor);
            }
        }
        
        InitializeDateAndTime(date,gametime);
    }

    private void InitializeDateAndTime(TextMeshProUGUI date, TextMeshProUGUI time)
    {
        date.text = timeScript.Month + " " + timeScript.Day;
        time.text = $"{timeScript.Hour:D2}:{timeScript.Minute:D2}";
    }

    private void LoadFishingScene()
    {
        inGameTime.UpdateScriptableObject();
        SceneManager.LoadScene(fishingScene);
    }

    private void LoadHuntingScene()
    {
        inGameTime.UpdateScriptableObject();
        SceneManager.LoadScene(hunterScene);
    }

    public void LoadHomeScene()
    {
        inGameTime.UpdateScriptableObject();
        SceneManager.LoadScene(homeScene);
    }
    
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log($"Сцена {scene.name} загружена!");
        location = scene.name;
        InitializeMainUI();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadHomeScene();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.gameObject.SetActive(!inventoryUI.gameObject.activeSelf);
        }
    }
}
