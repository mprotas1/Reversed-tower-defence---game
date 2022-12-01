using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

// script placed on Minion GameObject to handle movement site
public class Movement : MonoBehaviour
{
    private NavMeshAgent agent;
    private int indexOfCurrWaypoint = 0;
    private Waypoints waypoints;
    private Vector3 destination;
    private Animator animator;

    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();   
        waypoints = GameObject.Find("Checkpoints").GetComponent<Waypoints>();
    }

    public void Move()
    {
        agent.isStopped = false;
        Debug.Log(waypoints.getWaypoints()[indexOfCurrWaypoint].name);
        animator.Play("Run");
        agent.SetDestination(destination);
        SetMovDestination();
    }

    public void Stop()
    {
        agent.isStopped = true;
        animator.Play("Idle");
    }

    public void ReturnToLane()
    {
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

    /* 
     * getter and setter methods
    */
    public int GetIndex()
    {
        return indexOfCurrWaypoint;
    }

    public void SetIndex(int index)
    {
        indexOfCurrWaypoint = index;
    }

    private void SetMovDestination()
    {
        destination = waypoints.getWaypoints()[indexOfCurrWaypoint].position;
        indexOfCurrWaypoint++;
    }
}
