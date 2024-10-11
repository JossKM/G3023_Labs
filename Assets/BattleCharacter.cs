using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCharacter : MonoBehaviour
{
    private int hitPoints = 1;
    public int HitPoints { get { return hitPoints; } private set {  hitPoints = value; } }

    [Range(0, 1000)]
    public int defense = 1;
    public int strength = 0;
    public int dexterity = 0;
    public int intelligence = 0;

    public Dictionary<Effect, int> statusEffects = new Dictionary<Effect, int>();

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
