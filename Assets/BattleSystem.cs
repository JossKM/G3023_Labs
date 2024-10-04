using System;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    private static BattleSystem instance;
    public static BattleSystem Instance { get { 
            if(instance == null)
                instance = FindFirstObjectByType<BattleSystem>();
            return instance; 
        } private set { instance = value;} }

    public event Action<BattleSystem, BattleCharacter, BattleCharacter, Attack> OnAttack;
    public event Action<BattleSystem, BattleCharacter, BattleCharacter, Item> OnItemUse;

    public void UseItem(Item item, BattleCharacter caster, BattleCharacter target)
    {
        OnItemUse.Invoke(this, caster, target, item);
        Debug.Log("Used: " + name + " on " + target.name + "\n" + item.description);
        
        foreach (Effect effect in item.effects)
        {
            Attack asAttack = effect as Attack;
            if (asAttack != null)
            { 
                OnAttack.Invoke(this, caster, target, asAttack);
            }

            effect.Apply(caster, target);
        }
    }

    public static float GetDefenseScalar(BattleCharacter defender)
    {
        return (1.0f - (1.0f / defender.defense));
    }
}
