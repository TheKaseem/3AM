public class IdleState : IEnemyState
{
    public void OnEnter() { }
    public void OnExit() { }
    public void OnUpdate() { }
    public void OnEvent(string idleEvent) { }
}

public class WalkingState : IEnemyState
{
    public void OnEnter() { }
    public void OnExit() { }
    public void OnUpdate() { }
    public void OnEvent(string walkingEvent) { }
}

public class ChaseState : IEnemyState
{
    public void OnEnter() { }
    public void OnExit() { }
    public void OnUpdate() { }
    public void OnEvent(string chasingEvent) { }
}