using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusInstance
{
    public Effect effect;

    public void Apply(BattleCharacter caster, BattleCharacter target)
    {
        effect.Apply(caster, target);
    }
}

public class PoisonTickEffect : Effect
{
    public int tickValue;

    public override void Apply(BattleCharacter caster, BattleCharacter target)
    {
        target.TakeDamage(tickValue);
    }
}