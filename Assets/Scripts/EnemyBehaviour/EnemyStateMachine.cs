using UnityEngine;
using System.Collections.Generic;


public class EnemyStateMachine
{
    private Dictionary<EnemyStateType, IEnemyState> states = new();
    private IEnemyState currentState;
    private EnemyStateType currentType;

    public void Initialize(UnityEngine.AI.NavMeshAgent agent, Transform player, float walkSpeed, float chaseSpeed, float range)
    {
        states[EnemyStateType.Idle]    = new EnemyIdleState(this, 0f);
        states[EnemyStateType.Walking] = new EnemyWalkingState(this, agent, player, walkSpeed, range);
        states[EnemyStateType.Chasing] = new EnemyChaseState(this, agent, player, chaseSpeed, range);
        //Feed me more

        ChangeState(EnemyStateType.Idle);
    }

    public void ChangeState(EnemyStateType newState)
    {
        currentState?.OnExit();
        currentState = states[newState];
        currentType = newState;
        currentState?.OnEnter();
    }

    public void Update()
    {
        currentState?.OnUpdate();
    }

    public void HandleEvent(string eventName)
    {
        currentState?.OnEvent(eventName);
    }

    public EnemyStateType GetCurrentState() => currentType;
}
