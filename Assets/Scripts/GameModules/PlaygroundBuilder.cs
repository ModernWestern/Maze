using UnityEngine;
using System.Collections.Generic;

public class PlaygroundBuilder : MonoBehaviour
{
    const string Distractors = "FFCE00";
    const string Blocks = "000000";
    const string A_a = "B6134A";
    const string B_b = "00AB4C";

    const float Height = .25f;

    [SerializeField] private Texture2D[] levels;

    [SerializeField] private GameObject block, portal;

    public static readonly List<Vector3> DistractorPoints = new List<Vector3>();

    private readonly List<PortalBehaviour> Portals_A = new List<PortalBehaviour>();

    private readonly List<PortalBehaviour> Portals_B = new List<PortalBehaviour>();

    private void Awake()
    {
        Builder();

        SetPortals();
    }

    private void Builder()
    {
        DistractorPoints.Clear();

        var maze = levels[Random.Range(0, levels.Length)];

        for (int col = 0, w = maze.width; col < w; col++)
        {
            for (int row = 0, h = maze.height; row < h; row++)
            {
                var pixel = maze.GetPixel(col, row, 0);

                var position = new Vector3(col - (w / 2), Height, row - (h / 2));

                switch (ColorUtility.ToHtmlStringRGB(pixel))
                {
                    case Blocks:
                        Instantiate(block, position, Quaternion.identity, transform);
                        break;

                    case Distractors:
                        DistractorPoints.Add(position);
                        break;

                    case A_a:
                        Portals_A.Add(Instantiate(portal, position, Quaternion.identity, transform).AddComponent<PortalBehaviour>());
                        break;

                    case B_b:
                        Portals_B.Add(Instantiate(portal, position, Quaternion.identity, transform).AddComponent<PortalBehaviour>());
                        break;

                    default:
                        break;
                }
            }
        }
    }

    private void SetPortals()
    {
        Portals_A[0].Destination = Portals_A[1];

        Portals_A[1].Destination = Portals_A[0];

        Portals_B[0].Destination = Portals_B[1];

        Portals_B[1].Destination = Portals_B[0];
    }
}