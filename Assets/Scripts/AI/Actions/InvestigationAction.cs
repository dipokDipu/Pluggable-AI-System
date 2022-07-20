using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Investigation")]

public class InvestigationAction : Action
{
    public override void Act(StateController controller)
    {
        Investigation(controller);
    }

    public override void Exit(StateController controller)
    {
        Debug.Log("Exited from Investigation action");
    }

    private void Investigation(StateController controller)
    {
        controller.gameObject.GetComponent<TankCanvas>().SetTriggerUi(controller.TimeElapsed, controller.CurrentStat.InvestigationStateDuration);
    }
}
