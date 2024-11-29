using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

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
        SceneManager.LoadScene("Battle", LoadSceneMode.Additive);
        SceneManager.sceneLoaded += SceneLoadedListener;
        body = GetComponent<Rigidbody2D>();
    }

    public void SceneLoadedListener(Scene scene, LoadSceneMode mode)
    {
        encounter = FindFirstObjectByType<BattleSystem>().gameObject;
        encounter.SetActive(false);
    }

    [YarnCommand("StartBattle")]
    public void StartBattle(string name)
    {
        encounter.SetActive(true);
        gameObject.SetActive(false);
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
                    StartBattle("wild");
                    // Debug.Log("Encounter!" + tileData.areaName);
                }
            }
        }
       
    }
}
