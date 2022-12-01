using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionFollowLaneState : MinionBaseState
{
    private Movement movement;

    public override void EnterState(MinionStateManager minion)
    {
        Debug.Log("I'm in FollowLane state");
        movement = minion.GetComponent<Movement>();
        movement.Move();
    }

    public override void OnCollisionEnter(MinionStateManager minion, Collider other)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(MinionStateManager minion)
    {
        //Debug.Log(movement.GetIndex());
    }

}
