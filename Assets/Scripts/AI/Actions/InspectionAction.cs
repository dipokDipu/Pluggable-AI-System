using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Inspection")]

public class InspectionAction : Action
{
    public override void Act(StateController controller)
    {
        Inspect(controller);
    }

    private void Inspect(StateController controller)
    {
        controller.Agent.ResetPath();
        controller.Agent.destination = controller.SuspectedObject.FirstOrDefault().Key.transform.position;
        //controller.DecreaseTolerance(controller.SuspectedObject.FirstOrDefault().Key);
    }

    public override void Exit(StateController controller)
    {
        controller.SuspectedObject.FirstOrDefault().Key.layer = LayerMask.NameToLayer("Default");
        controller.SuspectedObject.Remove(controller.SuspectedObject.FirstOrDefault().Key);
        Debug.Log("exiting the inspect action");
    }
}
