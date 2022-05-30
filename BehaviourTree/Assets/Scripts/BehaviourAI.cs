using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BehaviourAI : MonoBehaviour
{
    private BTNode tree;
    public Transform target;
    private NavMeshAgent agent;
    public Blackboard bb;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        bb.SetValue<Transform>("target", target);
        tree = new BTSequence( new BTMoveTowards(bb, agent, agent.stoppingDistance), new BTWait(2));
    }

    // Update is called once per frame
    void Update()
    {
        tree.Run();
    }
}
