using UnityEngine;

[CreateAssetMenu(fileName = "NewFishData", menuName = "Data/Fish Data", order = 51)]
public class FishData : ScriptableObject
{
    public FishType fishType; 
    public string fishName;   
    public Sprite icon;       
    public int basePrice;     
}
