

using UnityEngine;

[CreateAssetMenu(fileName = "StatusApplication", menuName = "Effects/StatusApplication")]
public class StatusAttack : Effect
{
    public Effect toApply;
    public int duration = 1;

    public override void Apply(BattleCharacter caster, BattleCharacter target)
    {
        target.statusEffects.Add(toApply, duration);
    }
}

