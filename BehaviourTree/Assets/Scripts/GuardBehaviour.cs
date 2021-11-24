using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardBehaviour : MonoBehaviour
{
    [SerializeField] private float patrolWaitTime = 2f;
    [SerializeField] private Transform[] waypoints;
    private int waypointIndex = 0;

    private NavMeshAgent agent;
    private BTNode guardTree;

    // Start is called before the first frame update
    void Start()
    {
        guardTree = new BTSequence(new BTMoveTowards(waypoints[waypointIndex], agent, agent.stoppingDistance), new BTWait(patrolWaitTime));
    }

    // Update is called once per frame
    void Update()
    {
        guardTree.Run();
    }
}
