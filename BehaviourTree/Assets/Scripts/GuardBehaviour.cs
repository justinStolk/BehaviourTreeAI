using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardBehaviour : MonoBehaviour
{
    public Blackboard Bb { get; private set; }

    [SerializeField] private float viewingAngle = 90f;
    [SerializeField] private float viewingRange = 10f;
    [SerializeField] private float patrolWaitTime = 2f;

    [SerializeField] private WaypointSystem waypointSystem;

    private NavMeshAgent agent;
    private BTNode guardTree;

    // Start is called before the first frame update
    void Start()
    {
        Bb = new Blackboard();
        agent = GetComponent<NavMeshAgent>();
        Bb.SetValue("target", waypointSystem.waypoints[0]);
        guardTree = new BTSequence(new BTMoveTowards(Bb, agent, agent.stoppingDistance), 
            new BTWait(patrolWaitTime),
            new BTSetTarget(Bb, waypointSystem, "waypointSystem"));
    }

    // Update is called once per frame
    void Update()
    {
        guardTree.Run();
    }
}
