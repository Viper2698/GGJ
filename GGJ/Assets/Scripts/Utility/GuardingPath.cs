using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardingPath : MonoBehaviour
{
    const float sphereRadius = 0.2f;

    // highlight when path selected
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        DrawPath();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.gray;
        DrawPath();
    }

    private void DrawPath()
    {
        for (int index = 0; index < transform.childCount; index++)
        {
            Gizmos.DrawSphere(GetWaypointPosition(index), sphereRadius);

            int nextIndex = (index + 1) % transform.childCount;
            Gizmos.DrawLine(GetWaypointPosition(index), GetWaypointPosition(nextIndex));
        }
    }

    public Vector3 GetWaypointPosition(int index)
    {
        return transform.GetChild(index).position;
    }

    public int GetNextWaypoint(int currentWaypoint)
    {
        return (currentWaypoint + 1) % transform.childCount;
    }
}