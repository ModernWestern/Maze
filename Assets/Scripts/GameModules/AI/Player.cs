using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] private Events events;

    [SerializeField] private PlayerSettings playerSettings;

    [SerializeField] private NavMeshAgent agent;

    [SerializeField] private Camera cam;

    private void Awake()
    {
        var material = gameObject.GetComponent<Renderer>().material;

        material.SetColor("_Color", playerSettings.color);

        events.OnPlayerColorChange += color => material.SetColor("_Color", color);

        events.OnDistractorEnter += value =>
        {
            if (value)
            {
                gameObject.SetActive(false);
            }
        };

        events.OnGameOver += () =>
        {
            gameObject.SetActive(false);
        };
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            agent.destination = cam.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    public void Warp(Vector3 destination)
    {
        agent.Warp(destination);
    }
}