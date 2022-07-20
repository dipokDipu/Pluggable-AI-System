using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Flee")]

public class FleeAction : Action
{
    public override void Act(StateController controller)
    {
        Flee(controller);
    }

    private void Flee(StateController controller)
    {

        //if (Vector3.Distance(controller.transform.position, controller.ChaseTarget.transform.position) < 20f)
        //{
            controller.Agent.isStopped = false;
            controller.Agent.destination =
                (controller.transform.position - controller.ChaseTarget.transform.position).normalized * 5f +
                controller.transform.position;
            controller.Agent.speed = controller.CurrentStat.FastMoveSpeed;
            //}

    }

    public override void Exit(StateController controller)
    {
        controller.Agent.speed = controller.CurrentStat.NormalMoveSpeed;

        Debug.Log("exited form flee action");
    }
}
