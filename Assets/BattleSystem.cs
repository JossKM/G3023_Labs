using System;
using UnityEngine;
using UnityEngine.Events;

public class BattleSystem : MonoBehaviour
{
    private static BattleSystem instance;
    public static BattleSystem Instance { get { 
            if(instance == null)
                instance = FindFirstObjectByType<BattleSystem>();
            return instance; 
        } private set { instance = value;} }

    public event Action<BattleSystem, BattleCharacter, BattleCharacter, Attack> OnAttack;
    public event Action<BattleSystem, BattleCharacter, BattleCharacter, Effect> OnEffect;
    public event Action<BattleSystem, BattleCharacter, BattleCharacter, Item> OnItemUse;
    public UnityEvent<BattleCharacter> onTurnBegin;
    public UnityEvent<BattleCharacter> onTurnEnd;

    private static bool StatusEnded(EffectInstanceData e)
    {
        return e.duration <= 0;
    }

    public void BeginTurn(BattleCharacter character)
    {
        for(int i = 0; i < character.statusEffects.Count; i++)
        {
            character.statusEffects[i].effect.Apply(character, character);
            character.statusEffects[i].duration -= 1;
        }

        character.statusEffects.RemoveAll(StatusEnded);
    }

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

            OnEffect.Invoke(this, caster, target, effect);

            switch (effect.targetingType)
            {
                case TargetType.Target:
                    effect.Apply(caster, target);
                    break;
                case TargetType.Caster:
                    effect.Apply(caster, caster);
                    break;
                case TargetType.All:
                    effect.Apply(caster, target);
                    effect.Apply(caster, caster);
                    break;
                case TargetType.None:
                    break;
                case TargetType.Count:
                    throw new Exception("Invalid TargetingType");
            }
        }
    }

    public static float GetDefenseScalar(BattleCharacter defender)
    {
        return (1.0f / Mathf.Max(1, defender.defense));
    }
}
