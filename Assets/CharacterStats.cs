using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    mySubclass subclass;
    public class mySubclass
    {
        public int a;
    }

    [SerializeField]
    public Dictionary<string, int> Stats = new Dictionary<string, int>();

    // Start is called before the first frame update
    void Start()
    {
        Stats.Add("HealthMax", 10);
        Stats.Add("HealthCurrent", Stats["HealthMax"]);
        //Stats.Add("Poison", 5);
        //Stats.Add("DigEffect", 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
