using UnityEngine;

public class EnemyIdleState : IEnemyState
{
    private EnemyStateMachine stateMachine;
    float enemySpeed = 0f;

    public EnemyIdleState(EnemyStateMachine machine, float moveSpeed)
    {
        stateMachine = machine;
        enemySpeed = moveSpeed;
    }

    public void OnEnter()
    {
        Debug.Log("Enemy is on Idle");
    }

    public void OnUpdate()
    {
        
    }

    public void OnExit()
    {
        Debug.Log("Enemy stopped idling");
    }

    public void OnEvent(string eventName)
    {
        if (eventName == "WalkingState")
        {
            stateMachine.ChangeState(EnemyStateType.Walking);
        }
    }
}