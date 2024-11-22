using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PoisonTickEffect", menuName = "Effects/PoisonTickEffect")]
public class PoisonTickEffect : Effect
{
    public int tickValue;

    public override void Apply(BattleCharacter caster, BattleCharacter target, float power = 1)
    {
        target.TakeDamage((int)(tickValue * power));
    }
}