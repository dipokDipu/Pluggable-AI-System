using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateController : MonoBehaviour
{
    public State CurrentState;
    public State RemainState;
    [HideInInspector]public EnemyStat CurrentStat;
    public EnemyStat NormalStat;
    public EnemyStat AlertedStat;
    public Transform Eyes;

     public NavMeshAgent Agent;
    [HideInInspector] public Complete.TankShooting TankShooting;
    [HideInInspector] public List<Transform> Waypoints;
    [HideInInspector] public int WayPointIndex;
    [HideInInspector] public bool IsAIActive;
    [HideInInspector] public Transform ChaseTarget;
    [HideInInspector] public float TimeElapsed;
    [HideInInspector] public int CurrentTolerance;
    private GameObject _previousSuspiciousGameObject;
    public Dictionary<GameObject, float> SuspectedObject = new Dictionary<GameObject, float>();



    void Awake()
    {
        TankShooting = GetComponent<Complete.TankShooting>();
        Agent = GetComponent<NavMeshAgent>();
        CurrentStat = NormalStat;
    }

    public void InitializeAi(bool aiActivate, List<Transform> wayPoints)
    {
        Waypoints = wayPoints;
        IsAIActive = aiActivate;
        Agent.enabled = IsAIActive;
    }

    void Update()
    {
        if(!IsAIActive) return;
        CurrentState?.UpdateState(this);
    }

    void OnDrawGizmos()
    {
        if (CurrentState != null && Eyes != null)
        {
            Gizmos.color = CurrentState.SceneGizmoColor;
            Gizmos.DrawWireSphere(Eyes.position, CurrentStat.LookSphereCastRadius);
            Gizmos.DrawRay(Eyes.transform.position, Eyes.forward *3);
        }
    }

    public void SwitchState(State nextState)
    {
        if (nextState != RemainState)
        {
            CurrentState.ExitState(this);
            CurrentState = nextState;
        }
    }


    public bool TimePassed(float stateDuration)
    {
        TimeElapsed += Time.deltaTime;
        return TimeElapsed >= stateDuration;
    }

    public void DecreaseTolerance(GameObject suspiciousGameObject)
    {
        CurrentTolerance = suspiciousGameObject == _previousSuspiciousGameObject
            ? CurrentTolerance + 0
            : CurrentTolerance + 1;
        _previousSuspiciousGameObject = suspiciousGameObject;
    }

    public void AlertedStateEnemyStat()
    {
        CurrentStat = AlertedStat;
        Agent.speed = CurrentStat.NormalMoveSpeed;
        Agent.acceleration = CurrentStat.Accelaration;
        
    }

    public void NormalStateEnemyStat()
    {
        CurrentStat = NormalStat;
        Agent.speed = CurrentStat.NormalMoveSpeed;
        Agent.acceleration = CurrentStat.Accelaration;
        
    }
}
