using System;
using UnityEngine;

[Serializable]
public class StatScaling
{
    public int basePower = 1;
    public float strScalar = 1;
    public float dexScalar = 0;
    public float intScalar = 0;

    public float GetScaledPower(BattleCharacter caster)
    {
        float scaledPower = basePower
         + strScalar * caster.strength
         + dexScalar * caster.dexterity
         + intScalar * caster.intelligence;

        return scaledPower;
    }

}

public enum TargetType
{
    Target,
    Caster,
    All,
    None,
    Count
}

public abstract class Effect : ScriptableObject
{
    public TargetType targetingType;
    public abstract void Apply(BattleCharacter caster, BattleCharacter target);
}
