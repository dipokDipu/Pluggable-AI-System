using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "PluggableAI/Decisions/Investigate")]

public class InvestigationDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        return Investigate(controller);
    }

    private bool Investigate(StateController controller)
    {
        if (controller.TimePassed(controller.CurrentStat.InvestigationStateDuration))
        {
            return true;
        }
        else
        {
            controller.Agent.ResetPath();
            controller.GetComponent<Rigidbody>().velocity = Vector3.zero;
            controller.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            return false;
        }
        //return controller.TimePassed(controller.CurrentStat.InvestigationStateDuration);
    }
}
