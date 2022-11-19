using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public static Path Instance;
    public List<Transform> Points;

    private void Awake()
    {
        Instance = this;
    }

    public Transform GetPoint(int index)
    {
        if (index >= Points.Count) return null;

        return Points[index];
    }

    private void OnDrawGizmos()
    {
        foreach (var point in Points)
        {
            var radius = .5f;
            Gizmos.DrawWireSphere(point.position, radius);
        }

        for (int i = 0; i < Points.Count - 1; i++)
        {
            Gizmos.DrawLine(Points[i].position, Points[i + 1].position);
        }
    }
}
