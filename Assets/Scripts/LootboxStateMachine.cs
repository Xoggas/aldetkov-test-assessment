using AxGrid;
using AxGrid.Base;
using AxGrid.FSM;
using UnityEngine;

public class LootboxStateMachine : MonoBehaviourExt
{
    [OnAwake]
    private void CreateFsm()
    {
        Settings.Fsm = new FSM();
        Settings.Fsm.Add(new LootboxIdleState());
        Settings.Fsm.Add(new LootboxStartingState());
        Settings.Fsm.Add(new LootboxScrollingState());
        Settings.Fsm.Add(new LootboxStoppingState());
        Settings.Fsm.Add(new LootboxStoppedState());
    }

    [OnStart]
    private void StartFsm()
    {
        Settings.Fsm.Start(States.Idle);
    }

    [OnUpdate]
    private void UpdateFsm()
    {
        Settings.Fsm.Update(Time.deltaTime);
    }
}
