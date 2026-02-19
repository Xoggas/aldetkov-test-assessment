using AxGrid;
using AxGrid.FSM;

[State(States.Starting)]
public class LootboxStartingState : FSMState
{
    [Enter]
    private void OnEnter()
    {
        Settings.Model.Set(ModelConstants.IsStartButtonActive, false);
        Settings.Invoke(Events.StartScrolling);
    }

    [One(3f)]
    private void Wait3Seconds()
    {
        Parent.Change(States.Scrolling);
    }
}
