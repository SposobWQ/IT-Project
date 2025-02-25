using UnityEngine;

[System.Serializable]
public class Fish
{
    public FishData fishData;
    public float weight;
    public float length;

    public Fish(FishData fishData, float weight, float length)
    {
        this.fishData = fishData;
        this.weight = Random.Range(fishData.minWeight, fishData.maxWeight);
        this.length = Random.Range(fishData.minHeight, fishData.maxHeight);
    }

    public int GetPrice()
    {
        return Mathf.RoundToInt(fishData.basePrice * weight);
    }
}