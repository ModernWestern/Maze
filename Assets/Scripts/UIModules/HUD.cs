using UnityEngine;

public class HUD : Module
{
    [SerializeField] private Events events;

    [SerializeField] private GameSettings gameSettings;

    [SerializeField] private Transform lifeContent;

    private void Start()
    {
        var heart = lifeContent.GetChild(0);

        for (int i = 0, l = gameSettings.lifes - 1; i < l; i++)
        {
            Instantiate(heart, lifeContent);
        }

        events.OnDistractorEnter += value =>
        {
            if (!value)
            {
                if (lifeContent.childCount > 0)
                {
                    Destroy(lifeContent.GetChild(0).gameObject);
                }

                if (lifeContent.childCount == 1)
                {
                    events.GameOver();
                }
            }
        };
    }
}