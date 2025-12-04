using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private EnemyStateMachine stateMachine = new();
    private NavMeshAgent agent;
    private Transform player;

    public float walkSpeed = 2f;
    public float chaseSpeed = 4f;
    public float detectionRange = 10f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        stateMachine.Initialize(agent, player, walkSpeed, chaseSpeed, detectionRange);
    }

    void Update()
    {
        stateMachine.Update();
    }

    public void TriggerEvent(string eventName)
    {
        stateMachine.HandleEvent(eventName);
    }
}