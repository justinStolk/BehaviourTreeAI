using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BTMoveTowards : BTNode
{
    public Transform target;
    private NavMeshAgent agent;
    private float stopDistance;
    public BTMoveTowards(Transform _target, NavMeshAgent _agent, float _stopDistance)
    {
        stopDistance = _stopDistance;
        agent = _agent;
        target = _target;
        agent.stoppingDistance = stopDistance;
        agent.SetDestination(_target.position);
    }
    public override void OnEnter()
    {
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
