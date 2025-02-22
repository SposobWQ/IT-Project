using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player Data")]
public class PlayerData : ScriptableObject
{
    public int Hour;
    public int Minute;
    public int MonthIndex;
    public int Day;
    public int Year;
    public int DayOfWeekIndex;
    public int Money;
}
