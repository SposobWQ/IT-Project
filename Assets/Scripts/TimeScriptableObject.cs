using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TimeData", menuName = "Data/Time Data")]
public class TimeScriptableObject : ScriptableObject
{
    public int Hour;
    public int Minute;
    public string Month;
    public int Day;
}
