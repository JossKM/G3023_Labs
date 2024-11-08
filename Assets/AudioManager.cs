using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour, ISaveable
{
    public AudioSource musicSource;
    public AudioMixer masterMixer;

    Vector2 volumeRangeMinMax = new Vector2(-80,10);

    private string volumeParam = "MusicVolume";

    private static AudioManager instance = null;
    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindFirstObjectByType<AudioManager>();
            }
            return instance;
        }

        private set {}
    }

    public void SetMusicVolume(float volume)
    {
        float volumeDB = Mathf.Lerp(volumeRangeMinMax.x, volumeRangeMinMax.y, volume);
        masterMixer.SetFloat(volumeParam, volumeDB);
    }

    public float GetMusicVolume()
    {
        masterMixer.GetFloat(volumeParam, out float vol);
        float volumeNormalized = Mathf.InverseLerp(volumeRangeMinMax.x, volumeRangeMinMax.y, vol);
        return volumeNormalized;
    }

    // Start is called before the first frame update
    void Start()
    {
        if(this.gameObject == Instance.gameObject)
        {
            DontDestroyOnLoad(gameObject); // DontDestroyOnLoad the original
        } else
        {
            Destroy(gameObject); // Destroy AudioManager as it is not the original, to prevent duplicates if we have this in a scene we load twice
        }
    }

    public void Save(string saveName)
    {
        PlayerPrefs.SetFloat(volumeParam, GetMusicVolume());
    }

    public void Load(string saveName)
    {
        float volNormalized = PlayerPrefs.GetFloat(volumeParam);
        SetMusicVolume(volNormalized);
    }
}
