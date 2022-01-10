using UnityEngine;

public class Module : MonoBehaviour
{
    [SerializeField] private bool startAsActive;

    private CanvasGroup canvasGroup;

    public virtual bool IsActive
    {
        get => canvasGroup ? canvasGroup.alpha == 1 : gameObject.activeInHierarchy && isActiveAndEnabled;

        set
        {
            if (canvasGroup)
            {
                canvasGroup.alpha = value ? 1 : 0;

                canvasGroup.interactable = value;

                canvasGroup.blocksRaycasts = value;
            }
            else gameObject.SetActive(value);
        }
    }

    public virtual void Awake()
    {
        IsActive = startAsActive;

        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}