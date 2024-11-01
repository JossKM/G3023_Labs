using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] 
// This is an Attribute in C#, specifically it is one defined by the...
// Unity API called RequireComponent which means this component cannot exist on a...
// GameObject without the other required component type
public class Movement2D : MonoBehaviour, ISaveable
{
    [SerializeField] // SerializeField is an attribute which says that this variable can be saved,
                     // and will be saved in the scene
    public Rigidbody2D rb;

    public const string posX = "PosX";
    public const string posY = "PosY";

    [Range(0f, 100f)]
    public float moveSpeed = 6;

    public void Load(string saveName)
    {
        float x = PlayerPrefs.GetFloat(saveName + posX);
        float y = PlayerPrefs.GetFloat(saveName + posY);
        transform.position = new Vector3(x, y, transform.position.z);
    }

    public void Save(string saveName)
    {
        PlayerPrefs.SetFloat(saveName + posX, transform.position.x);
        PlayerPrefs.SetFloat(saveName + posY, transform.position.y);
    }  

    // Start is called before the first frame update
    void Start()
    {
        SaveGame.OnSaveEvent += Save;
        SaveGame.OnLoadEvent += Load;

        rb = GetComponent<Rigidbody2D>();
    }

    void OnDestroy()
    {
        SaveGame.OnSaveEvent -= Save;
        SaveGame.OnLoadEvent -= Load;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector =
            new Vector2(
                Input.GetAxisRaw("Horizontal"),
                Input.GetAxisRaw("Vertical")
                );

        rb.velocity = inputVector.normalized * moveSpeed;

        Vector3 position;
        position.x = 1;
    }
}
