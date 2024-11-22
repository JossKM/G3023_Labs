

using UnityEngine;

[CreateAssetMenu(fileName = "StatusApplication", menuName = "Effects/StatusApplication")]
public class StatusApplication : Effect
{
    public Effect toApply;
    public int duration = 1;
    StatScaling scaling;

    public override void Apply(BattleCharacter caster, BattleCharacter target)
    {
        float scaledPower = scaling.GetScaledPower(caster);
        target.statusEffects.Add(new EffectInstanceData(toApply, duration, scaledPower));
    }
}

