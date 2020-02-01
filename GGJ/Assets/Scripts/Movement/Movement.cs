using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    [SerializeField] float maxPathDistance = 40f;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void StartMovement(Vector3 location)
    {
        if (navMeshAgent.isActiveAndEnabled)
        {
            navMeshAgent.destination = location;
            navMeshAgent.isStopped = false;
        }
    }

    public bool CanMoveTo(Vector3 destination)
    {
        NavMeshPath path = new NavMeshPath();
        bool canReachLocation = NavMesh.CalculatePath(transform.position, destination, NavMesh.AllAreas, path);

        if (!canReachLocation)
            return false;
        if (path.status != NavMeshPathStatus.PathComplete)
            return false;
        if (PathLength(path) > maxPathDistance)
            return false;

        return true;
    }

    private float PathLength(NavMeshPath path)
    {
        float totalDistance = 0;

        if (path.corners.Length < 2)
            return totalDistance;

        for (int index = 0; index < path.corners.Length - 1; index++)
        {
            float distance = Vector3.Distance(path.corners[index], path.corners[index + 1]);
            totalDistance += distance;
        }

        return totalDistance;
    }

    public void ChangeSpeed(float newSpeed)
    {
        navMeshAgent.speed = newSpeed;
    }

    public void Cancel()
    {
        if (navMeshAgent.isActiveAndEnabled)
            navMeshAgent.isStopped = true;
    }
}
