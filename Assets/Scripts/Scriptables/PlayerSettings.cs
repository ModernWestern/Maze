using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSettings", menuName = "ScriptableObjects/PlayerSettings", order = 2)]
public class PlayerSettings : ScriptableObject
{
    public Color color;

    private void OnEnable()
    {
        color = Color.white;
    }
}