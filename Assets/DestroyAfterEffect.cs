using UnityEngine;

[RequireComponent(typeof(AudioSource), typeof(ParticleSystem))]
public class DestroyAfterEffect : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;

    private void OnParticleSystemStopped()
    {
        Destroy(gameObject, audioSource.clip.length);
    }
}
