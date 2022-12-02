using System;
using System.Collections.Generic;
using WrongTurn.StateManagement;
using WrongTurn.StateManagement.Actions.Base;

public class SaveStateModel
{
    public Guid PlayerId { get; set; }
    public PlayerState PlayerState { get; set; }
    public IEnumerable<PlayerAction> Actions { get; set; }
}
