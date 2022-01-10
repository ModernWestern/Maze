using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Events", menuName = "ScriptableObjects/Events", order = 3)]
public class Events : ScriptableObject
{
    public event Action OnSettings;

    public event Action<Color> OnPlayerColorChange;

    public event Action<AudioClip> OnBackgroundMusicChange;

    public event Action<bool> OnDistractorEnter;

    public event Action OnGameOver;

    public void Settings()
    {
        OnSettings?.Invoke();
    }

    public void PlayerColorChange(Color color)
    {
        OnPlayerColorChange?.Invoke(color);
    }

    public void BackgroundMusicChange(AudioClip clip)
    {
        OnBackgroundMusicChange?.Invoke(clip);
    }

    public void GameOver()
    {
        OnGameOver?.Invoke();
    }

    public void DistractorEnter(bool value)
    {
        OnDistractorEnter?.Invoke(value);
    }

    public void CleanAll()
    {
        OnSettings = null;

        OnPlayerColorChange = null;

        //OnBackgroundMusicChange = null;

        OnGameOver = null;

        OnDistractorEnter = null;
    }
}