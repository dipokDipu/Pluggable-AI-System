using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[CreateAssetMenu(menuName = "PluggableAI/Actions/Suspicious Object Detection")]

public class CheckSuspiciousObjectAction : Action
{
    
    public override void Act(StateController controller)
    {
        CheckForSuspiciousObject(controller);
    }

    private void CheckForSuspiciousObject(StateController controller)
    {
        controller.SuspectedObject.Clear();
        Collider[] targetsInViewRadius = Physics.OverlapSphere(controller.transform.position, controller.CurrentStat.SuspiciousObjectDetectionRadius);
        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - controller.transform.position).normalized;
            if (Vector3.Angle(controller.transform.forward, dirToTarget) < controller.CurrentStat.SuspiciousObjectDetectionViewingAngle / 2)
            {
                float dstToTarget = Vector3.Distance(controller.transform.position, target.position);

                RaycastHit hit;
                if (Physics.Raycast(controller.transform.position, dirToTarget, out hit, dstToTarget, controller.CurrentStat.SuspiciousLayerMask))
                {
                    controller.SuspectedObject.Add(target.gameObject, dstToTarget);
                }
            }
        }

        controller.SuspectedObject = controller.SuspectedObject.
            OrderBy(obj => obj.Value).
            ToDictionary(obj => obj.Key, obj => obj.Value);

    }

    public override void Exit(StateController controller)
    {
        //controller.SuspectedObject.Clear();
        Debug.Log("exiting from suspicious object checking");
    }
}
