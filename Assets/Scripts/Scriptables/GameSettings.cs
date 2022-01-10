using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObjects/GameSettings", order = 1)]
public class GameSettings : ScriptableObject
{
    public bool GameOver { get; set; }

    [Tooltip("Time in seconds")]
    public float time = 300;

    public TimeType timeType;

    [Range(1, 10)]
    public int lifes = 3;
}