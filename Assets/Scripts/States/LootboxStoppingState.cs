using AxGrid;
using AxGrid.FSM;

[State(States.Stopping)]
public class LootboxStoppingState : FSMState
{
    [Enter]
    private void Awake()
    {
        Settings.Model.Set(ModelConstants.IsStopButtonActive, false);
        Settings.Invoke(Events.StopScrolling);
    }

    [One(3f)]
    private void Wait3Seconds()
    {
        Parent.Change(States.Stopped);
    }
}
