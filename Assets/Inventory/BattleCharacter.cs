using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCharacter : MonoBehaviour
{
    private int hitPoints = 1;
    public int HitPoints { get { return hitPoints; } private set {  hitPoints = value; } }

    public void TakeAttack(int attackValue)
    {
        hitPoints -= attackValue;
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
