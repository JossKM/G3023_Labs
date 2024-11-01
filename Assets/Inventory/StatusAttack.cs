public class StatusAttack : Effect
{
    public StatusInstance toApply;
    public int stacks = 1;

    public override void Apply(BattleCharacter caster, BattleCharacter target)
    {
        target.statusEffects.Add(toApply, stacks);
    }
}
