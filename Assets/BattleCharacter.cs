using System;
using System.Collections;
using System.Collections.Generic;
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

public class BattleCharacter : MonoBehaviour
{
    private int hitPoints = 1;
    public int HitPoints { get { return hitPoints; } private set {  hitPoints = value; } }

    [Range(0, 1000)]
    public int defense = 1;
    public int strength = 0;
    public int dexterity = 0;
    public int intelligence = 0;

    public List<EffectInstanceData> statusEffects;

    public void TakeDamage(int damageValue)
    {
        hitPoints -= damageValue;
    }

    public void TakeHealing(int healValue)
    {
        hitPoints += healValue;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
