using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusAttack : Effect
{
    public StatusInstance toApply;

    public override void Apply(BattleCharacter caster, BattleCharacter target)
    {
        target.statusEffects.Add(toApply, 1);
    }
}
