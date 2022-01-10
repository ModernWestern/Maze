using UnityEngine;

public class PortalBehaviour : MonoBehaviour
{
    public bool AllowWarp { get; set; } = true;

    public PortalBehaviour Destination { get; set; }

    public Vector3 Position => gameObject.transform.position;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destination.AllowWarp = false;

            if (AllowWarp)
            {
                other.GetComponent<Player>().Warp(Destination.Position);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AllowWarp = true;
        }
    }
}