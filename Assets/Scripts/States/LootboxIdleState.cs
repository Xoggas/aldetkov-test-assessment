using AxGrid;
using AxGrid.FSM;
using AxGrid.Model;

[State(States.Idle)]
public class LootboxIdleState : FSMState
{
    [Enter]
    private void OnEnter()
    {
        Settings.Model.Set(ModelConstants.IsStartButtonActive, true);
        Settings.Model.Set(ModelConstants.IsStopButtonActive, false);
    }

    [Bind(Events.ButtonClicked)]
    private void StartScrolling(string buttonName)
    {
        if (buttonName.Equals(Buttons.StartButton))
        {
            Parent.Change(States.Starting);
        }
    }
}
