public interface IEnemyState
{
    void OnEnter();
    void OnExit();
    void OnUpdate();
    void OnEvent(string eventName);
}
