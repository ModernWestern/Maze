using System.Linq;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    const string Background = "Background";

    [SerializeField] private Events events;

    [SerializeField] private AudioSource[] sources;

    private void Awake()
    {
        if (this != FindObjectOfType<SoundManager>())
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        events.OnBackgroundMusicChange += BackgroundMusicChange;
    }

    private void BackgroundMusicChange(AudioClip clip)
    {
        var source = sources.FirstOrDefault(source => source.name == Background);

        source.Stop();

        source.clip = clip;

        source.Play();
    }
}