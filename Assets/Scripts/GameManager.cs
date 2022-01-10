using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Events events;

    [SerializeField] private GameSettings game;

    [SerializeField] private PlayerSettings player;

    private void Awake()
    {
        Application.targetFrameRate = 30;
    }

    private void Start()
    {
        events.OnPlayerColorChange += PlayerColorChange;
    }

    private void PlayerColorChange(Color color)
    {
        player.color = color;
    }
}