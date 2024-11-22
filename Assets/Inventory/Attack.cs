using UnityEngine;

[CreateAssetMenu(fileName = "DamageEffect", menuName = "Effects/Damage")]
public class Attack : Effect
{
    public StatScaling scaling;

    public override void Apply(BattleCharacter caster, BattleCharacter target, float power = 1)
    {
        float scaledAttack = scaling.GetScaledPower(caster) * power;

        float defenseMitigation = BattleSystem.GetDefenseScalar(target);

        scaledAttack *= defenseMitigation;

        target.TakeDamage(Mathf.CeilToInt(scaledAttack));
    }
}
