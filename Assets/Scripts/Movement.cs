using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

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
        if(indexOfCurrWaypoint <= waypoints.getWaypoints().Length) 
        {
            // check if reached the waypoint
            Debug.Log(IsCurrentWaypointReached());
            if(IsCurrentWaypointReached())
            {
                indexOfCurrWaypoint++;
                destination = waypoints.getWaypoints()[indexOfCurrWaypoint].position;
                Debug.Log(indexOfCurrWaypoint);
                agent.SetDestination(destination);
            }
        }
    }

    private bool IsCurrentWaypointReached()
    {
        Debug.Log(Vector3.Distance(gameObject.transform.position, destination));
        if (Vector3.Distance(gameObject.transform.position, destination) <= 2.0f) {
            Debug.Log("Reached waypoint");
            return true;
        }
        else
        {
            return false;
        }
    }
}
