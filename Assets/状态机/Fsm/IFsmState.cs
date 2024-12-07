namespace IdleGame.Fsm
{
    public interface IFsmState
    {
        FsmStateId StateId { get; }
        public void SetMachine(FsmSystem system);
        void EnterState();
        void StateUpdate(float deltaTime);
        void ExitState();
        FsmStateId CheckCanTranslateState(FsmTranslationCondition condition);
    }
}