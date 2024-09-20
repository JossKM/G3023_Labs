using UnityEngine;

public class EncounterTile : MonoBehaviour
{
    public string areaName;
    public float encounterChance = 0.5f;

    public bool RollEncounter()
    {
        return Random.value <= encounterChance;
    }
}
