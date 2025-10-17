using UnityEngine;
using System.Collections.Generic;


public class EnemyStateMachine
{
    private Dictionary<EnemyStateType, IEnemyState> states = new();
    private IEnemyState currentState;
    private EnemyStateType currentType;

    public void Initialize()
    {
        states[EnemyStateType.Idle] = new EnemyIdleState(this, 0f); //machine + speed
        states[EnemyStateType.Walking] = new EnemyWalkingState(this, 0f); // machine + speed
        //More states

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
