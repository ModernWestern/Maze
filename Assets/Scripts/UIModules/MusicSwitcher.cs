using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class MusicSwitcher : MonoBehaviour
{
    const string path = "Music/Background";

    public event Action<AudioClipData> OnSwitch;

    [SerializeField] private Dropdown dropdown;

    private readonly List<AudioClipData> Clips = new List<AudioClipData>();

    private static int currentClip;

    private void Awake()
    {
        dropdown.ClearOptions();

        Clips.Add(new AudioClipData());

        dropdown.onValueChanged.AddListener(option =>
        {
            OnSwitch?.Invoke(Clips.FirstOrDefault(clip => clip.GetAlias() == dropdown.options[option].text));

            currentClip = option;
        });

        var clips = Resources.LoadAll<AudioClip>(path);

        for (int i = 0, l = clips.Length; i < l; i++)
        {
            Clips.Add(new AudioClipData(clips[i], $"{clips[i].name.Split('_')[0]}"));
        }

        dropdown.AddOptions(Clips.Select(clip => clip.GetAlias()).ToList());

        dropdown.SetValueWithoutNotify(currentClip);
    }
}

public class AudioClipData
{
    private readonly string Alias;

    private readonly AudioClip Clip;

    public string GetAlias() => Alias;

    public AudioClip GetClip() => Clip;

    public AudioClipData()
    {
        Clip = null;

        Alias = "None";
    }

    public AudioClipData(AudioClip clip, string alias)
    {
        Clip = clip;

        Alias = alias;
    }
}