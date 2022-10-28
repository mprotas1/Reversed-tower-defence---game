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

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        waypoints = GameObject.Find("Waypoints").GetComponent<Waypoints>();
        destination = waypoints.getWaypoints()[indexOfCurrWaypoint].position;
        
        agent.SetDestination(destination);
    }

    // Update is called once per frame
    void Update()
    {
        if(indexOfCurrWaypoint < waypoints.getWaypoints().Length) 
        {
            // check if reached the waypoint
            if(IsCurrentWaypointReached())
            {
                indexOfCurrWaypoint++;
                destination = waypoints.getWaypoints()[indexOfCurrWaypoint].position;
                agent.SetDestination(destination);
            }
        }
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
}
