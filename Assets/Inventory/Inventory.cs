using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public BattleCharacter owner;
    public List<ItemSlot> slots = new List<ItemSlot>();
    public TextMeshProUGUI itemDescription;

    private void OnValidate()
    {
        UpdateSlotList();
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateSlotList();
    }

    void UpdateSlotList()
    {
        slots = new List<ItemSlot>();
        ItemSlot[] childSlots = GetComponentsInChildren<ItemSlot>();
        slots.AddRange(childSlots);

        foreach(ItemSlot slot in slots)
        {
            slot.inventory = this;
        }
    }
}
