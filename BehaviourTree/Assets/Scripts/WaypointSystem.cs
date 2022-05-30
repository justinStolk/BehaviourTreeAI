using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointSystem : MonoBehaviour
{
    public Transform[] waypoints;
    private int waypointIndex = 0;

    public Transform GetNewWaypoint()
    {
        waypointIndex++;
        if(waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0;
        }
        return waypoints[waypointIndex];
    }
}
