using UnityEngine;

public class SampleTexture : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer sprite;

    [SerializeField]
    Vector2 uv;

    [SerializeField]
    Vector2Int texturePos;

    public Color sampledColor;

    // Update is called once per frame
    void Update()
    {
        Vector3 relativeToTexture = transform.position - sprite.transform.position;
        relativeToTexture -= sprite.bounds.center;
        uv = new Vector2(relativeToTexture.x / sprite.bounds.size.x, (relativeToTexture.y / sprite.bounds.size.y));
        uv = uv + new Vector2(0.5f, 0.5f);
        texturePos = new Vector2Int(Mathf.RoundToInt(sprite.sprite.texture.width * uv.x), Mathf.RoundToInt(sprite.sprite.texture.height * uv.y));
        sampledColor = sprite.sprite.texture.GetPixel(texturePos.x, texturePos.y);


    }
}
