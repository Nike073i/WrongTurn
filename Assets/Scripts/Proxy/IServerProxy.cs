using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WrongTurn.StateManagement;
using WrongTurn.StateManagement.Actions.Base;

public interface IServerProxy
{
    Task<PlayerState?> GetByPlayerId(Guid playerId);
    Task<PlayerState> SaveState(Guid playerId, PlayerState playerState, IEnumerable<PlayerAction> actions);
    Task<bool> UnlockAchievement(Guid playerId, string achievementId);
    Task<Guid?> CreatePlayer();
}
