using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour, ISaveable
{
    public BattleCharacter owner;
    public List<ItemSlot> slots = new List<ItemSlot>();
    public static ItemTable mainTable;

    public const string inventoryKey = "Inventory";

    public void Load(string saveName)
    {
        string inventoryString = PlayerPrefs.GetString(saveName + inventoryKey);
        // Split string by comma -1,0,0,-1,1,2
        string[] items = inventoryString.Split(',');
        for (int slot = 0; slot < slots.Count; slot++)
        {
            string itemString = items[slot];
            int id = int.Parse(itemString);
            slots[slot].itemInSlot = mainTable.GetItemByID(id);
        }
    }

    // Creates a string of a series of item IDs, separated by commas e.g. -1,0,0,-1,1,2
    public void Save(string saveName)
    {
        string inventoryString = "";
        for(int slot = 0; slot < slots.Count; slot++)
        {
            int id = -1;

            Item item = slots[slot].itemInSlot;
            if (item != null)
            {
                id = item.ItemID;
            }

            string itemString = id.ToString();
            inventoryString += itemString + ",";
        }

        PlayerPrefs.SetString(saveName + inventoryKey, inventoryString);
    }

    private void OnValidate()
    {
        UpdateSlotList();
    }

    // Start is called before the first frame update
    void Start()
    {
        mainTable = (ItemTable)Resources.Load("MainItemTable");
        SaveGame.OnSaveEvent += Save;
        SaveGame.OnLoadEvent += Load;
        UpdateSlotList();
    }

    void OnDestroy()
    {
        SaveGame.OnSaveEvent -= Save;
        SaveGame.OnLoadEvent -= Load;
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
