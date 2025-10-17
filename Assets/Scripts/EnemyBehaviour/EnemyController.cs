using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private EnemyStateMachine stateMachine = new();

    void Start()
    {
        stateMachine.Initialize();
        stateMachine.ChangeState(EnemyStateType.Idle);
    }

    void Update()
    {
        stateMachine.Update();
    }

    public void TriggerEvent(string eventName)
    {
        stateMachine.HandleEvent(eventName);
    }

    public void SetState(EnemyStateType newState)
    {
        stateMachine.ChangeState(newState);
    }
}
