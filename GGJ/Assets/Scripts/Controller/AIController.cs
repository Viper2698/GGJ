using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [SerializeField] float eyesHeight = 1f;
    [SerializeField] float fovDistance = 4f;
    [SerializeField] float fohDistance = 1.5f;
    [Header("Suspicion")]
    [SerializeField] float suspicionTime = 5f;
    [SerializeField] float sensedPlayerCooldown = 5f;
    [Header("Path")] 
    [SerializeField] GuardingPath path;
    [SerializeField] float deltaDistanceToWaypoint = 1f;
    [SerializeField] float timeBetweenWaypoints = 3f;
    [Header("Speed")]
    [Range(0, 5)]
    [SerializeField] float patrolSpeed = 2.5f;
    [Range(0, 5)]
    [SerializeField] float chaseSpeed = 4.5f;

    Vector3 initialPosition;

    // enemy AI memory
    GameObject player;
    Attack attack;
    Health health;
    Movement movement;
    float FOVangle = 60;

    float timeSinceWaypointArrival = Mathf.Infinity;
    float timeSincePlayerDisappeared = Mathf.Infinity;
    float timeSinceSensedPlayer = Mathf.Infinity;
    int currentWaypoint;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        attack = GetComponent<Attack>();
       // health = GetComponent<Health>();
        movement = GetComponent<Movement>();
    }

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //if (health.IsDead())
        //    return;

        player = GameObject.FindWithTag("Player");
        
       // if (player == null)
        //    timeSincePlayerDisappeared = 0;

        if (HasSensedEnemy() && attack.CanAttack(player)) // attack state
        {
            FOVangle = 360;
            print("player was sensed");
            AttackState();
        }
        else if (timeSincePlayerDisappeared <= suspicionTime) // suspicion state
        {
            FOVangle = 180;
            SuspicionState();
        }
        else // back to guarding state
        {
            FOVangle = 60;
            PatrolState();
        }

        UpdateTimers();
    }

    private void UpdateTimers()
    {
        timeSinceWaypointArrival += Time.deltaTime;
        timeSincePlayerDisappeared += Time.deltaTime;
        timeSinceSensedPlayer += Time.deltaTime;
    }

    private void PatrolState()
    {
        Vector3 nextPosition = initialPosition;
        attack.Cancel();

        if (path != null)
        {
            if (HaveReachedWaypoint())
            {
                movement.Cancel();
                timeSinceWaypointArrival = 0;
                GetNextWaypoint();
            }
            nextPosition = GetCurrentWaypointPosition();
        }

        // player not in the field of view
        // enemies lost interest and stopped

        // go back to your initial position or previous path waypoint
        // guard that location
        if (timeSinceWaypointArrival > timeBetweenWaypoints)
        {
            movement.StartMovement(nextPosition);
        }
    }

    private bool HaveReachedWaypoint()
    {
        return Vector3.Distance(transform.position, GetCurrentWaypointPosition())
                < deltaDistanceToWaypoint;
    }

    private void GetNextWaypoint()
    {
        currentWaypoint = path.GetNextWaypoint(currentWaypoint);
    }

    private Vector3 GetCurrentWaypointPosition()
    {
        return path.GetWaypointPosition(currentWaypoint);
    }

    private void SuspicionState()
    {
        movement.ChangeSpeed(patrolSpeed);
        movement.Cancel();
    }

    private void AttackState()
    {
        timeSincePlayerDisappeared = 0;
        attack.AttackCharacter(player);
        movement.ChangeSpeed(chaseSpeed);
    }

    private bool HasSensedEnemy()
    {
        // is the player in this object's field of view?
        var computedDistance = Vector3.Distance(player.transform.position, transform.position);
        Vector3 direction = player.transform.position - transform.position;
        float angle = Vector3.Angle(transform.forward, direction);

        if (Mathf.Abs(angle) <= FOVangle * 0.5f)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position + transform.up * eyesHeight, direction.normalized, out hit, fovDistance))
            {
                if (hit.collider.gameObject == player)
                {
                    Debug.DrawRay(transform.position, direction, Color.green);
                    return true;
                }
            }
        }
        else if (computedDistance <= fohDistance)
            return true;


        return false;

    }

    // called whenever gizmos has to be drawn(when the object is selected) - by unity
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, fohDistance);
    }
}
