using System;
using System.Collections.Generic;
using CodeBase.Systems.CoroutineRunner;
using CodeBase.Systems.GameStateMachine.States;
using Zenject;

namespace CodeBase.Systems.GameStateMachine
{
    public class GameStateMachine : IGameStateMachine
    {
        private readonly IInstantiator _instantiator;
        
        private Dictionary<Type, IExitableState> _states;
        private IExitableState _currentState;

        public GameStateMachine(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        public void BindStates()
        {
            _states = new Dictionary<Type, IExitableState>()
            {
                [typeof(BootstrapState)] = _instantiator.Instantiate<BootstrapState>(),
                [typeof(LoadGameplaySceneState)] = _instantiator.Instantiate<LoadGameplaySceneState>(),
            };
        }
        
        public void Enter<TState>() where TState : class, IState
        {
            var state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState
        {
            var state = ChangeState<TState>();
            state.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _currentState?.Exit();
                
            var state = GetStateByType<TState>();
            _currentState = state;
            return state;
        }

        private TState GetStateByType<TState>() where TState : class, IExitableState
        {
            var state = _states[typeof(TState)];
            return state as TState;
        }
    }
}