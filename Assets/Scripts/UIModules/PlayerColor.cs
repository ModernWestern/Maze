using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerColor : MonoBehaviour
{
    public event Action<Color> OnChange;

    [SerializeField] private PlayerSettings playerSettings;

    [SerializeField] private Slider slider;

    [SerializeField] private Image colorRef;

    private void Awake()
    {
        slider.minValue = 0;

        slider.maxValue = 1;

        Color.RGBToHSV(playerSettings.color, out float h, out _, out _);

        colorRef.color = playerSettings.color;

        slider.value = h;

        slider.onValueChanged.AddListener(value =>
        {
            var color = colorRef ? (colorRef.color = Color.HSVToRGB(value, 1, 1)) : Color.HSVToRGB(value, 1, 1);

            OnChange?.Invoke(color);
        });
    }
}