using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/EnemyStat")]
public class EnemyStat : ScriptableObject
{
    public float NormalMoveSpeed;
    public float FastMoveSpeed;
    public float Accelaration;
    public float LookRange;
    public float LookSphereCastRadius;
    public float AttackRange;
    public float AttackRate;
    public float AttackForce;
    public int AttackDamage;
    public float SearchDuration;
    public float SearchingTurnSpeed;
    public float InvestigationStateDuration;
    public float FleeTankHealth;
    public float OutOfRangeFleeDistance;
    public float FleeAttackRate;

    public float SuspiciousObjectDetectionRadius;
    public float SuspiciousObjectDetectionViewingAngle;
    public LayerMask SuspiciousLayerMask;

    public int SuspectedObjectTolerance;
    public float SuspicousObjectExaminationDuration;

    public float AlertStateDuration;
}
