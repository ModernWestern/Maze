using UnityEngine;
using UnityEngine.UI;

public class GUI : Module
{
    [SerializeField] private Events events;

    [SerializeField] private Button settings;

    private void Start()
    {
        settings.onClick.AddListener(() =>
        {
            events.Settings();
        });
    }
}