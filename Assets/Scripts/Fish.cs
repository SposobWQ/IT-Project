using UnityEngine;

[System.Serializable]
public class Fish
{
    public FishData fishData; // Постоянные данные о рыбе
    public float weight; // Вес рыбы (переменное)
    public float length; // Длина рыбы (переменное)

    public Fish(FishData fishData, float weight, float length)
    {
        this.fishData = fishData;
        this.weight = weight;
        this.length = length;
    }

    public int GetPrice()
    {
        // Пример расчёта цены на основе веса и базовой цены
        return fishData.basePrice + Mathf.RoundToInt(weight * 10);
    }
}