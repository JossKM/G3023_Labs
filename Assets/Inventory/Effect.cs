using System;
using UnityEngine;

public class EffectInstanceData
{
    public Effect effect;
    public int duration;
    public float power;

    public EffectInstanceData(Effect effect, int duration, float power)
    {
        this.effect = effect;
        this.duration = duration;
        this.power = power;
    }
}

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
    public abstract void Apply(BattleCharacter caster, BattleCharacter target, float power = 1);
}
