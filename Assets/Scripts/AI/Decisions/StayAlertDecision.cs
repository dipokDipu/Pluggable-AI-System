using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Alert Stay")]

public class StayAlertDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        return StayAlert(controller);
    }

    private bool StayAlert(StateController controller)
    {
        Debug.Log("Alert State :" + !(controller.TimePassed(controller.CurrentStat.AlertStateDuration)));
        return !(controller.TimePassed(controller.CurrentStat.AlertStateDuration));
    }
}
