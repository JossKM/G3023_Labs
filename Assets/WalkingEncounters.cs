using UnityEngine;

public class WalkingEncounters : MonoBehaviour
{
    [SerializeField]
    GameObject encounter;

    [SerializeField]
    public Rigidbody2D body;

    [Range(0f, 100f)] 
    [SerializeField]
    public float distancePerRoll = 1;

    public float distanceSinceLastRoll = 0;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        EncounterTile tileData = collision.GetComponent<EncounterTile>();
        if (tileData == null ) { return; }

        if (body.velocity.sqrMagnitude > 0)
        {
            distanceSinceLastRoll += body.velocity.magnitude * Time.fixedDeltaTime;

            while(distanceSinceLastRoll > distancePerRoll )
            {
                distanceSinceLastRoll -= distancePerRoll;

                if (tileData.RollEncounter())
                {
                    encounter.SetActive(true);
                    Debug.Log("Encounter!" + tileData.areaName);
                }
            }
        }
       
    }
}
