using UnityEngine;

public class EnemyWalkingState : IEnemyState
{
    private EnemyStateMachine stateMachine;
    private UnityEngine.AI.NavMeshAgent agent;
    private Transform player;
    private float enemySpeed;
    public float detectionRange = 10f;

    private float patrolTimer = 0f;
    private float patrolCooldown = 3f;
    private float patrolRadius = 5f;

    public EnemyWalkingState(EnemyStateMachine machine, UnityEngine.AI.NavMeshAgent navAgent, Transform playerTarget, float moveSpeed, float range)
    {
        stateMachine = machine;
        agent = navAgent;
        player = playerTarget;
        enemySpeed = moveSpeed;
        detectionRange = range;
    }

    public void OnEnter()
    {
        Debug.Log("Enemy started walking");
        agent.speed = enemySpeed;
        agent.updateRotation = true;
        agent.updateUpAxis = true;
    }

    public void OnUpdate()
{
    float distance = Vector3.Distance(agent.transform.position, player.position);

    if (distance <= detectionRange)
    {
        stateMachine.HandleEvent("chaseEvent");
        return;
    }
    else
    {
        patrolTimer += Time.deltaTime;
        if (patrolTimer >= patrolCooldown || agent.remainingDistance <= agent.stoppingDistance)
        {
            SetRandomPatrolPoint();
            patrolTimer = 0f;
        }
    }
}

    public void OnExit()
    {
        Debug.Log("Enemy stopped walking");
    }

    public void OnEvent(string eventName)
    {
        if (eventName == "chaseEvent")
        {
            Debug.Log("Enemy is chasing player!");
            stateMachine.ChangeState(EnemyStateType.Chasing);
        }
    }

    private void SetRandomPatrolPoint()
    {
        Vector3 randomDir = Random.insideUnitSphere * patrolRadius;
        randomDir += agent.transform.position;

        UnityEngine.AI.NavMeshHit hit;
        if (UnityEngine.AI.NavMesh.SamplePosition(randomDir, out hit, patrolRadius, UnityEngine.AI.NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }
}