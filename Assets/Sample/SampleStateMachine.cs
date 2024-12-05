using Xeon.StateMachine;

public enum SampleState
{
    State1,
    State2,
    State3,
    State4
}

public class SampleStateMachine : StateMachine<SampleState, IState>
{
}
