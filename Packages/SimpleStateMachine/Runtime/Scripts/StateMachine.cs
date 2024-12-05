using System;
using System.Collections.Generic;

namespace Xeon.StateMachine
{
    public class StateMachine<TEnum, TState> : IDisposable
        where TEnum : Enum
        where TState : IState
    {
        protected TEnum currentState;
        protected TEnum nextState;
        protected object bridgeParam = null;
        protected Dictionary<TEnum, TState> states = new();

        public TEnum CurrentState => currentState;
        public TState State => states[currentState];

        public virtual void AddState(TEnum state, TState instance)
            => states[state] = instance;

        public void Goto(TEnum nextState, object bridgeParam = null)
        {
            this.nextState = nextState;
            this.bridgeParam = bridgeParam;
        }

        public void Initialize(TEnum firstState, object param = null)
        {
            currentState = firstState;
            State.OnEnter(param);
        }

        public void Update()
        {
            if (currentState.Equals(nextState))
            {
                State?.Update();
                return;
            }

            State.OnExit();
            currentState = nextState;
            State.OnEnter(bridgeParam);
            bridgeParam = null;
        }

        public virtual void Dispose()
        {
        }
    }
}
