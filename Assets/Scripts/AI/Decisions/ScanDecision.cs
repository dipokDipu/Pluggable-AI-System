using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Scan")]

public class ScanDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        return Scan(controller);
    }

    private bool Scan(StateController controller)
    {
        controller.Agent.isStopped = true;
        controller.transform.Rotate(0, controller.CurrentStat.SearchingTurnSpeed* Time.deltaTime, 0);
        return controller.TimePassed(controller.CurrentStat.SearchDuration);
    }
}
