using UnityEngine;

public class Waypoints : MonoBehaviour
{
    // an array for waypoints
    private Transform[] waypoints;

    void Awake()
    {
        // here I'm getting the reference to all the waypoints

        waypoints = new Transform[transform.childCount];

        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = transform.GetChild(i);
        }
    }

    public Transform[] getWaypoints()
    {
        return this.waypoints;
    }
}
