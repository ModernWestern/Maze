using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private const string Format = "mm':'ss";

    [SerializeField] private GameSettings settings;

    [SerializeField] private Text timer;

    private Helpers.Timer timerRoutine;

    private void Awake()
    {
        if (settings.timeType == TimeType.None)
        {
            timer.gameObject.SetActive(false);
        }
        else
        {
            if (settings.timeType == TimeType.Backward)
            {
                timer.text = TimeSpan.FromSeconds(settings.time).ToString(Format);
            }

            timerRoutine = new Helpers.Timer(settings.time, settings.timeType switch
            {
                TimeType.Backward => true,
                _ => false
            });
        }
    }

    private void Start()
    {
        timerRoutine?.Start(() => settings.GameOver, time =>
        {
            timer.text = TimeSpan.FromSeconds(time).ToString(Format);

        }, () => Debug.Log("Completed!!!"), this);
    }
}