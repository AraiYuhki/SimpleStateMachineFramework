#if XEON_STATEMACHINE_INPUT_SUPPORT
using System;
using UnityEngine.InputSystem;

namespace Xeon.StateMachine
{
    public class StateMachineWithInput<TEnum, TState, TInput>
        : StateMachine<TEnum, TState>
        where TEnum : Enum
        where TState : IStateWithInput<TInput>, new()
        where TInput : IInputActionCollection2, IDisposable
    {
        protected TInput input;
        public StateMachineWithInput(TInput input)
            => this.input = input;

        public override void AddState(TEnum state, TState instance)
        {
            instance.SetInput(input);
            base.AddState(state, instance);
        }

        public override void Dispose()
        {
            base.Dispose();
            input?.Dispose();
            input = default;
        }
    }
}
#endif
