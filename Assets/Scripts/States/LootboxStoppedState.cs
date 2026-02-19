using AxGrid.FSM;

[State(States.Stopped)]
public class LootboxStoppedState : FSMState
{
    [One(1f)]
    private void Wait1Second()
    {
        Parent.Change(States.Idle);
    }
}