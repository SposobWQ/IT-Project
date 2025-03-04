using UnityEngine;

[CreateAssetMenu(fileName = "NewFishData", menuName = "Data/Fish Data", order = 51)]
public class FishData : ScriptableObject
{
    public FishType fishType; 
    public string fishName;   
    public Sprite icon;       
    public int basePrice;     
    public float minWeight;
    public float maxWeight;
    public float minHeight;
    public float maxHeight;
    public int minMonthIndex;
    public int maxMonthIndex;
    public int minDay;
    public int maxDay;
    public int fineCost;
}
