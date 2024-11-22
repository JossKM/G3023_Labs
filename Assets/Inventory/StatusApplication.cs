

using UnityEngine;

[CreateAssetMenu(fileName = "StatusApplication", menuName = "Effects/StatusApplication")]
public class StatusApplication : Effect
{
    public Effect toApply;
    public int duration = 1;
    public StatScaling scaling;

    public override void Apply(BattleCharacter caster, BattleCharacter target, float power = 1)
    {
        float scaledPower = scaling.GetScaledPower(caster) * power;
        target.statusEffects.Add(new EffectInstanceData(toApply, duration, scaledPower));
    }
}

