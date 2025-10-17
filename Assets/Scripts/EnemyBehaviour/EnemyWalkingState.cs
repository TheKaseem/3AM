using UnityEngine;

public class EnemyWalkingState : IEnemyState
{
    private EnemyStateMachine stateMachine;
    private float enemySpeed;

    public EnemyWalkingState(EnemyStateMachine machine, float moveSpeed)
    {
        stateMachine = machine;
        enemySpeed = moveSpeed;
    }

    public void OnEnter()
    {
        Debug.Log("Enemy started walking");
    }

    public void OnUpdate()
    {
        
    }

    public void OnExit()
    {
        Debug.Log("Enemy stopped walking");
    }

    public void OnEvent(string eventName)
    {
        if (eventName == "chaseEvent")
        {
            //
        }
    }
}