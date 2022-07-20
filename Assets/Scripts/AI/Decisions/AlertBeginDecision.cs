using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Alert Begin")]

public class AlertBeginDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        return Alerted(controller);
    }

    private bool Alerted(StateController controller)
    {
        return controller.CurrentTolerance >= controller.CurrentStat.SuspectedObjectTolerance;
    }
}
