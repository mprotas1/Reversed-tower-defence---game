using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionDeadState : MinionBaseState
{
    public override void EnterState(MinionStateManager minion)
    {
        // play dead animation

        // destroy the object
        Object.Destroy(minion.gameObject);
    }

    public override void OnCollisionEnter(MinionStateManager minion, Collider other)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(MinionStateManager minion)
    {
        throw new System.NotImplementedException();
    }

}
