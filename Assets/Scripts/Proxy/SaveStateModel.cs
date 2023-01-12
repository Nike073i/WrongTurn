using Assets.Scripts.Proxy;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using WrongTurn.StateManagement;
using WrongTurn.StateManagement.Actions.Base;

public class SaveStateModel
{
    public Guid PlayerId { get; set; }
    public PlayerState PlayerState { get; set; }

    [JsonConverter(typeof(PlayerActionConverter))]
    [JsonProperty(PropertyName = "Actions")]
    public IEnumerable<IPlayerAction> Actions { get; set; }
}
