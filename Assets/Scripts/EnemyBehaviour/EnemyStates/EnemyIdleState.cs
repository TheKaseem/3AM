using UnityEngine;

public class EnemyIdleState : IEnemyState
{
    private EnemyStateMachine stateMachine;
    private float enemySpeed = 0f;

    private float idleDuration;
    private float idleTimer;

    public EnemyIdleState(EnemyStateMachine machine, float moveSpeed)
    {
        stateMachine = machine;
        enemySpeed = moveSpeed;
    }

    public void OnEnter()
    {
        Debug.Log("Enemy is on Idle");

        idleDuration = Random.Range(2f, 5f);
        idleTimer = 0f;
    }

    public void OnUpdate()
    {
        idleTimer += Time.deltaTime;

        if (idleTimer >= idleDuration)
        {
            stateMachine.ChangeState(EnemyStateType.Walking);
        }
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
