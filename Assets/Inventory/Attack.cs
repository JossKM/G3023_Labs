using UnityEngine;

[CreateAssetMenu(fileName = "DamageEffect", menuName = "Effects/Damage")]
public class Attack : Effect
{
    StatScaling scaling;

    public override void Apply(BattleCharacter caster, BattleCharacter target)
    {
        float scaledAttack = scaling.GetScaledPower(caster);

        float defenseMitigation = BattleSystem.GetDefenseScalar(target);

        scaledAttack *= defenseMitigation;

        target.TakeDamage(Mathf.CeilToInt(scaledAttack));
    }
}
