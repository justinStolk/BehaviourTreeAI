using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BTMoveTowards : BTNode
{
    public Transform target;
    private NavMeshAgent agent;
    private float stopDistance;

    private Blackboard blackboard;
    public BTMoveTowards(Blackboard _blackboard, NavMeshAgent _agent, float _stopDistance)
    {
        blackboard = _blackboard;
        stopDistance = _stopDistance;
        agent = _agent;
        target = blackboard.GetValue<Transform>("target"); ;
        agent.stoppingDistance = stopDistance;
        agent.SetDestination(target.position);
    }
    public override void OnEnter()
    {
        target = blackboard.GetValue<Transform>("target");
        if (!agent.pathPending && !agent.hasPath)
        {
            agent.SetDestination(target.position);
        }
        initialised = true;
    }
    public override void OnExit()
    {
        initialised = false;
    }
    public override BTResult Run()
    {
        if (Vector3.Distance(agent.destination, agent.gameObject.transform.position) <= stopDistance)
        {
            return BTResult.Success;
        }
        if(agent.pathStatus == NavMeshPathStatus.PathInvalid)
        {
            return BTResult.Failed;
        }
        return BTResult.Running;
     
    }
}
