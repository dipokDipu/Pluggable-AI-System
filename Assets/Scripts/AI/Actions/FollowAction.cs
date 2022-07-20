using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "PluggableAI/Actions/Follow")]
public class FollowAction : Action
{
    public override void Act(StateController controller)
    {
        Follow(controller);
    }

    

    private void Follow(StateController controller)
    {
        controller.Agent.destination = controller.ChaseTarget.position;
        controller.Agent.speed = controller.CurrentStat.NormalMoveSpeed/2f;
    }

    public override void Exit(StateController controller)
    {
        controller.Agent.ResetPath();
        controller.Agent.speed = controller.CurrentStat.NormalMoveSpeed;
    }

}
