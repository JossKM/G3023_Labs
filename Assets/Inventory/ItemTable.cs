using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Table", menuName = "Items/Create Item Table")]
public class ItemTable : ScriptableObject
{
    [SerializeField]
    private List<Item> items = new List<Item>();

    public Item GetItemByID(int id)
    {
        if(id < 0)
        {
            return null;
        }

        return items[id];
    }

    public void SetItemIDs()
    {
        for(int id = 0; id < items.Count; id++)
        {
            try
            {
                items[id].ItemID = id;
            }
            catch(ItemIDChangeException) {}
        }
    }
}
