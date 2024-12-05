namespace Xeon.StateMachine
{
    public interface IState
    {
        void OnEnter(object bridgeParam);
        void OnExit();
        void Update();
        void InputUpdate();
    }
}
