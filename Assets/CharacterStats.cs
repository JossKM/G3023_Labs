using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    //Dictionary is the C# equivalent of std::map<TKey,TValue>
    public Dictionary<string, int> stats = new Dictionary<string, int>();

    // Start is called before the first frame update
    void Start()
    {
        stats.Add("HitPoints", 10);
        stats.Add("Strength", 20);
        stats.Add("Intelligence", 0);
        stats.Add("Agility", 1);
    }
}
