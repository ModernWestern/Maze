using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Events events;

    [SerializeField] private GUI gui;

    [SerializeField] private HUD hud;

    [SerializeField] private Settings settings;

    private void Start()
    {
        events.OnSettings += Settings;

        events.OnDistractorEnter += value =>
        {
            if (value)
            {
                gui.Disable();

                hud.Disable();

                settings.Disable();
            }
        };

        events.OnGameOver += () =>
        {
            gui.Disable();

            hud.Disable();

            settings.Disable();
        };
    }

    private void Settings()
    {
        settings.IsActive = !settings.IsActive;

        hud.IsActive = !hud.IsActive;
    }
}