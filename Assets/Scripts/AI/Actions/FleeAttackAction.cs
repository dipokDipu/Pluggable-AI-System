using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "PluggableAI/Actions/Flee & Attack")]

public class FleeAttackAction : Action
{

    public override void Act(StateController controller)
    {
        FleeAndAttack(controller);
    }

    private void FleeAndAttack(StateController controller)
    {
        if (Vector3.Distance(controller.transform.position, controller.ChaseTarget.transform.position) > controller.CurrentStat.OutOfRangeFleeDistance/4f && controller.TimePassed(controller.CurrentStat.FleeAttackRate))
        {
            controller.transform.LookAt(controller.ChaseTarget);
            controller.TankShooting.Fire(controller.CurrentStat.AttackForce);
            controller.TimeElapsed = 0;
        }
        
    }

    public override void Exit(StateController controller)
    {
        controller.TimeElapsed = 0;
        Debug.Log("exited form flee and attack action");
    }
}
