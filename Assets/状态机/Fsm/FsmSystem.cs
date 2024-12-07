using System.Collections.Generic;
using UnityEngine;

namespace IdleGame.Fsm
{
    public class FsmSystem
    {
        //子弟啊存储所有状态
        private readonly Dictionary<FsmStateId, IFsmState> _states;

        //当前激活的状态
        private IFsmState _currentState;
        public IFsmState CurrentState => _currentState;

        public FsmSystem()
        {
            _states = new Dictionary<FsmStateId, IFsmState>(10);
        }
        public FsmSystem(IFsmController controller)
        {
            _states = new Dictionary<FsmStateId, IFsmState>(10);
        }
        //添加状态
        public void AddState(IFsmState state)
        {
            if (!_states.ContainsKey(state.StateId))
            {
                _states[state.StateId] = state;
                state.SetMachine(this);
            }
        }

        //切换状态
        public void Translate(FsmTranslationCondition condition)
        {
            if (condition==FsmTranslationCondition.None)
            {
                Debug.LogWarning($"Can't translate state by none condition!");
                return;
            }

            var targetStateId = CurrentState.CheckCanTranslateState(condition);
            if (targetStateId == FsmStateId.None || !_states.TryGetValue(targetStateId, out var state))
            {
                Debug.Log($"Invalid State:{targetStateId},{_states.ContainsKey(targetStateId)}");
                return;
            }
            CurrentState.ExitState();
            //Debug.Log($"Change State '{_currentState.StateId}'->'{state.StateId}'");
            _currentState = state;
            CurrentState.EnterState();
        }

        //开始状态
        public void StartState(FsmStateId stateId)
        {
            if (_states.TryGetValue(stateId,out var state))
            {
                state.EnterState();
                _currentState = state;
            }
            else
            {
                Debug.LogWarning($"Invalid State!");
            }
        }

        //更新状态
        public void UpdateState(float deltaTime)
        {
            _currentState?.StateUpdate(deltaTime);
        }
    }
}