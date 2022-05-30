using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTSetTarget : BTNode
{
    private Blackboard blackboard;
    private string waypointSystemName;
    public BTSetTarget(Blackboard _blackboard, WaypointSystem _waypointSystem, string _waypointSystemName)
    {
        blackboard = _blackboard;
        waypointSystemName = _waypointSystemName;
        blackboard.SetValue<WaypointSystem>(waypointSystemName, _waypointSystem);
    }
    public override BTResult Run()
    {
        Transform newTarget = blackboard.GetValue<WaypointSystem>(waypointSystemName).GetNewWaypoint();
        blackboard.SetValue<Transform>("target", newTarget);
        return BTResult.Success;
    }
}
