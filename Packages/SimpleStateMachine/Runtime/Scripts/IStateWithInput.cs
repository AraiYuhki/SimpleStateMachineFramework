#if XEON_STATEMACHINE_INPUT_SUPPORT
using System;
using UnityEngine.InputSystem;

namespace Xeon.StateMachine
{
    public interface IStateWithInput<TInput> : IState
        where TInput : IInputActionCollection2, IDisposable
    {
        void SetInput(TInput input);
    }
}
#endif
