using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Items/Create Item")]
public class Item : ScriptableObject
{
    public Sprite sprite;
    public int value = 0;
    public string description = "Default Description";
    public List<Effect> effects = new List<Effect>();

    public void Use(BattleCharacter target)
    {
        Debug.Log("Used: " + name + " on " + target.name + "\n" + description);

        foreach(Effect effect in effects)
        {
            effect.Apply(target, target);
        }
    }
}
