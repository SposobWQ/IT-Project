using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainUIData : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI time;
    [SerializeField] private TextMeshProUGUI date;
    [SerializeField] private TextMeshProUGUI dialogueName;
    [SerializeField] private TextMeshProUGUI dialogue;
    [SerializeField] private GameObject pcui;
    [SerializeField] private GameObject dateObject;
    [SerializeField] private GameObject doorUI;
    [SerializeField] private Button closeDoorUI;
    [SerializeField] private Button closePCUI;
    [SerializeField] private Button fishingButton;
    [SerializeField] private Button huntButton;
    [SerializeField] private Image dayImage;
    [SerializeField] private GameObject inventoryUIObject;
    [SerializeField] private Image sleepImage;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button continueButton;
    [SerializeField] private GameObject pause;

    public TextMeshProUGUI Time
    {
        get => time;
        set => time = value;
    }

    public Image DayImage
    {
        get => dayImage;
        set => dayImage = value;
    }

    public TextMeshProUGUI Date
    {
        get => date;
        set => date = value;
    }

    public TextMeshProUGUI DialogueName
    {
        get => dialogueName;
        set => dialogueName = value;
    }

    public TextMeshProUGUI Dialogue
    {
        get => dialogue;
        set => dialogue = value;
    }
    public GameObject PCUI
    {
        get => pcui;
        set => pcui = value;
    }
    public GameObject DateObject
    {
        get => dateObject;
        set => dateObject = value;
    }
    public GameObject DoorUI
    {
        get => doorUI;
        set => doorUI = value;
    }

    public Button CloseDoorUI
    {
        get => closeDoorUI;
        set => closeDoorUI = value;
    }

    public Button ClosePCUI
    {
        get => closePCUI;
        set => closePCUI = value;
    }

    public Button FishingButton
    {
        get => fishingButton;
        set => fishingButton = value;
    }

    public Button HuntButton
    {
        get => huntButton;
        set => huntButton = value;
    }

    public GameObject InventoryUIObject
    {
        get => inventoryUIObject;
        set => inventoryUIObject = value;
    }

    public Image SleepImage
    {
        get => sleepImage;
        set => sleepImage = value;
    }

    public TextMeshProUGUI MoneyText
    {
        get => moneyText;
        set => moneyText = value;
    }

    public Button ExitButton
    {
        get => exitButton;
        set => exitButton = value;
    }

    public Button ContinueButton
    {
        get => continueButton;
        set => continueButton = value;
    }

    public GameObject PauseObject
    {
        get => pause;
        set => pause = value;
    }
}
