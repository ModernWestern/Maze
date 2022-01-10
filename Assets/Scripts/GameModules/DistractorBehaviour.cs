using TMPro;
using System;
using UnityEngine;

public class DistractorBehaviour : MonoBehaviour
{
    public Action<bool> Selected;

    public bool Value { get; set; }

    public string Text
    {
        get => text.text;

        set => text.text = value;
    }

    [SerializeField] private TMP_Text text;

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Selected?.Invoke(Value);
        }
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}