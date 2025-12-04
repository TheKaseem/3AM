using UnityEngine;

public class EnemyChaseState : IEnemyState
{
    private EnemyStateMachine stateMachine;
    private UnityEngine.AI.NavMeshAgent agent;
    private Transform player;
    private float enemySpeed;
    public float detectionRange = 10f;

    public EnemyChaseState(EnemyStateMachine machine, UnityEngine.AI.NavMeshAgent navAgent, Transform playerTarget, float moveSpeed, float range)
    {
        stateMachine = machine;
        agent = navAgent;
        player = playerTarget;
        enemySpeed = moveSpeed;
        detectionRange = range;
    }

    public void OnEnter()
    {
        Debug.Log("Enemy started chasing");
        agent.speed = enemySpeed;
    }

    public void OnUpdate()
    {
        float distance = Vector3.Distance(agent.transform.position, player.position);

        if (distance <= detectionRange)
        {
            agent.SetDestination(player.position);
        }
        else
        {
            agent.SetDestination(agent.transform.position); 
        }
    }

    public void OnExit()
    {
        Debug.Log("Enemy stopped chasing");
    }

    public void OnEvent(string eventName)
    {
        if (eventName == "chaseEvent")
        {
            Debug.Log("Enemy is chasing player!");
            agent.SetDestination(player.position);
        }
    }
}