using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject UI;
    [SerializeField] private TimeScriptableObject timeScript;
    [SerializeField] private string location;
    
    public GameObject PCUI;
    public GameObject doorUI;
    
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
        PCUI.SetActive(!PCUI.activeSelf);
    }

    public void ButtonClickDoor()
    {
        doorUI.SetActive(!doorUI.activeSelf);
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
        
        MainUIData uiData = ui[0].GetComponent<MainUIData>();

        TextMeshProUGUI gametime = uiData.Time;
        Image dayImage = uiData.DayImage;
        TextMeshProUGUI date = uiData.Date;
        TextMeshProUGUI dialogueName = uiData.DialogueName; 
        TextMeshProUGUI dialogue = uiData.Dialogue;
        
        InitializeDateAndTime(date,gametime);
    }

    private void InitializeDateAndTime(TextMeshProUGUI date, TextMeshProUGUI time)
    {
        date.text = timeScript.Month + " " + timeScript.Day;
        time.text = $"{timeScript.Hour:D2}:{timeScript.Minute:D2}";
    }
    
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log($"Сцена {scene.name} загружена!");
        InitializeMainUI();
    }
}
