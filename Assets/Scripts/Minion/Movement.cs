using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class Movement : MonoBehaviour
{
    private NavMeshAgent agent;
    private int indexOfCurrWaypoint = 0;
    private Waypoints waypoints;
    private Vector3 destination;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();   
        waypoints = GameObject.Find("Checkpoints").GetComponent<Waypoints>();
        destination = waypoints.getWaypoints()[indexOfCurrWaypoint].position;

        Move();
    }

    public void Move()
    {
        if (indexOfCurrWaypoint < waypoints.getWaypoints().Length)
        {
            // check if reached the waypoint
            if (IsCurrentWaypointReached())
            {
                indexOfCurrWaypoint++;
                destination = waypoints.getWaypoints()[indexOfCurrWaypoint].position;
                agent.SetDestination(destination);
                animator.Play("Run");
            }
        }
    }

    public void ReturnToLane()
    {
        indexOfCurrWaypoint++;
        destination = waypoints.getWaypoints()[indexOfCurrWaypoint].position;
        agent.SetDestination(destination);
        animator.Play("Run");
    }

    private bool IsCurrentWaypointReached()
    {
        if (Vector3.Distance(gameObject.transform.position, destination) <= 2.0f) {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int GetIndex()
    {
        return indexOfCurrWaypoint;
    }

    public void SetIndex(int index)
    {
        indexOfCurrWaypoint = index;
    }
}
