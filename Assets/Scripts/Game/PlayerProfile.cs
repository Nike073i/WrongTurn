using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrongTurn.StateManagement;
using WrongTurn.StateManagement.Actions.Balance;
using WrongTurn.StateManagement.Actions.Base;
using Zenject;

namespace Assets.Scripts.Game
{
    public class PlayerProfile
    {
        private IServerProxy _server;
        private List<IPlayerAction> _unsavedActions;

        public Guid PlayerId { get; private set; }
        public Store GameStore { get; private set; }
        public IEnumerable<IPlayerAction> UnsavedActions { get => _unsavedActions; }

        [Inject]
        public async Task Construct(IServerProxy serverProxy)
        {
            _server = serverProxy;
            PlayerId = SystemInfo.GetMachineGuid();
            var playerState = await LoadPlayerState();
            GameStore = new Store(playerState);
            _unsavedActions = new List<IPlayerAction>();

            //CheatTest();
        }

        //private void CheatTest()
        //{
        //    CompleteAction(new RebalancingAction(150));
        //    CompleteAction(new RebalancingAction(-250));
        //    GameStore = new Store(new PlayerState(400000, new List<string>()));
        //}

        public void CompleteAction(IPlayerAction playerAction)
        {
            GameStore.Dispatch(playerAction);
            _unsavedActions.Add(playerAction);
        }

        private void ClearActionList() => _unsavedActions.Clear();

        private async Task<PlayerState> LoadPlayerState() => await _server.GetByPlayerId(PlayerId) ?? PlayerState.NewPlayerState();

        public async Task Synchronization()
        {
            if (!UnsavedActions.Any()) return;
            var playerState = await _server.SaveState(PlayerId, GameStore.PlayerState, UnsavedActions);
            if (playerState != null) GameStore = new Store(playerState);
            ClearActionList();
        }
    }
}
