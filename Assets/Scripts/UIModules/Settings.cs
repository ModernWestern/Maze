using UnityEngine;

public class Settings : Module
{
    [SerializeField] private Events events;

    [SerializeField] private PlayerColor playerColor;

    [SerializeField] private MusicSwitcher musicSwitcher;

    public override bool IsActive
    {
        get => base.IsActive;

        set
        {
            base.IsActive = value;

            Time.timeScale = value ? 0 : 1;
        }
    }

    private void Start()
    {
        playerColor.OnChange += PlayerColorChange;

        musicSwitcher.OnSwitch += data => events.BackgroundMusicChange(data.GetClip());
    }

    private void PlayerColorChange(Color color)
    {
        events.PlayerColorChange(color);
    }
}