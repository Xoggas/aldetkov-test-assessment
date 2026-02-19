using AxGrid;
using AxGrid.FSM;
using AxGrid.Model;

[State(States.Scrolling)]
public class LootboxScrollingState : FSMState
{
    [Enter]
    private void OnEnter()
    {
        Settings.Model.Set(ModelConstants.IsStopButtonActive, true);
    }

    [Bind(Events.ButtonClicked)]
    private void OnButtonClicked(string buttonName)
    {
        if (buttonName.Equals(Buttons.StopButton))
        {
            Parent.Change(States.Stopping);
        }
    }
}
