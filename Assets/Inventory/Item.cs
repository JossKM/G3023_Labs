using System.Collections.Generic;
using UnityEngine;

public class ItemIDChangeException : System.Exception
{ 
}

[CreateAssetMenu(fileName = "NewItem", menuName = "Items/Create Item")]
public class Item : ScriptableObject
{
    private int itemID = 1;
    public int ItemID {  
        get { return itemID; } 
        
        set {
            itemID = value;
            throw new ItemIDChangeException();
        } 
    }

    public Sprite sprite;
    public int value = 0;
    public string description = "Default Description";
    public List<Effect> effects = new List<Effect>();

    public void Use(BattleCharacter caster, BattleCharacter target)
    {
        Debug.Log("Used: " + name + " on " + target.name + "\n" + description);

        foreach(Effect effect in effects)
        {
            effect.Apply(caster, target);
        }
    }
}
