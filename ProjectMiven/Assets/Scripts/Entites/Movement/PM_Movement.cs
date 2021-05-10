using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[Serializable]
public class PM_Movement
{
    [SerializeField] PM_Entity owner;

    [SerializeField] NavMeshAgent agent;

    public void InitMovement(PM_Entity _owner)
    {
        owner = _owner;

        if (!agent)
            agent = owner.GetComponent<NavMeshAgent>();
    }

    public void Move(Vector3 _newPos)
    {
        agent.SetDestination(_newPos);
    }

}
