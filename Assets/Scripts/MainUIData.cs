using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainUIData : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI time;
    [SerializeField] private Image dayImage;
    [SerializeField] private TextMeshProUGUI date;
    [SerializeField] private TextMeshProUGUI dialogueName;
    [SerializeField] private TextMeshProUGUI dialogue;

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
}
