using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Fish> fishInventory = new List<Fish>();

    private GameObject inventoryUIObject;

    public void AddFish(Fish fish)
    {
        fishInventory.Add(fish);
    }

    public void RemoveFish(Fish fish)
    {
        fishInventory.Remove(fish);
    }
}
