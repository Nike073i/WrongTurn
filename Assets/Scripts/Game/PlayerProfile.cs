using System;
using System.Threading.Tasks;

namespace Assets.Scripts.Game
{
    public class PlayerProfile
    {
        private readonly LocalDataStore _localDataStore;
        private readonly IServerProxy _serverProxy;
        public Guid? PlayerId { get; private set; }

        public PlayerProfile(LocalDataStore localDataStore, IServerProxy serverProxy)
        {
            _localDataStore = localDataStore;
            _serverProxy = serverProxy;
        }

        public void LoadData()
        {
            var localData = _localDataStore.Load();
            if (localData == null) return;
            PlayerId = localData.PlayerId;
        }

        public void SaveData()
        {
            if (!PlayerId.HasValue) return;
            var data = new LocalData
            {
                PlayerId = PlayerId.Value,
            };
            _localDataStore.Save(data);
        }

        public async Task CreateProfile()
        {
            var playerId = await _serverProxy.CreatePlayer();
            if (playerId == null) throw new InvalidProgramException();
        }
    }
}
