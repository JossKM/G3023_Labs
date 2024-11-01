using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour, ISaveable
{
    public BattleCharacter owner;
    public List<ItemSlot> slots = new List<ItemSlot>();
    public ItemTable mainTable = null;

    private const string keyName = "Items";

    public void Load()
    {
        if (PlayerPrefs.HasKey(gameObject.name + keyName))
        {
            string inventoryString = PlayerPrefs.GetString(gameObject.name + keyName);

            string[] itemStrings = inventoryString.Split(",", System.StringSplitOptions.RemoveEmptyEntries);

            int slot = 0;
            for (; slot < itemStrings.Count() && slot < slots.Count(); slot++)
            {
                int id = int.Parse(itemStrings[slot]);

                slots[slot].itemInSlot = mainTable.GetItemByID(id);
            }

            while(slot < slots.Count())
            {
                slots[slot].itemInSlot = null;
                slot++;
            }

            foreach(ItemSlot itemSlot in slots)
            {
                itemSlot.Refresh();
            }
        }
    }

    public void Save()
    {
        string inventoryString = "";

        for(int slot = 0; slot < slots.Count; slot++)
        {
            int itemID = -1;
            Item item = slots[slot].itemInSlot;

            if(item != null)
            {
                itemID = item.ItemID;
            } 

            string itemString = itemID.ToString();

            inventoryString += itemString + ",";
        }

        PlayerPrefs.SetString(gameObject.name + keyName, inventoryString);
    }

    private void OnValidate()
    {
        UpdateSlotList();
    }

    // Start is called before the first frame update
    void Start()
    {
        SaveGame.onSaveEvent += Save;
        SaveGame.onLoadEvent += Load;

        UpdateSlotList();
    }

    void OnDestroy()
    {
        SaveGame.onSaveEvent -= Save;
        SaveGame.onLoadEvent -= Load;
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
