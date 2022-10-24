using System.Collections;
using System.Collections.Generic;
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
            if(agent.destination.x == destination.x && agent.destination.z == destination.z)
            {
                Debug.Log("Reached destination... Changing the index");
                indexOfCurrWaypoint++;
                agent.SetDestination(waypoints.getWaypoints()[indexOfCurrWaypoint].position);
            }
        }
    }
}
