using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using WrongTurn.StateManagement.Actions.Base;

namespace Assets.Scripts.Proxy
{
    internal class PlayerActionConverter : JsonConverter<IEnumerable<IPlayerAction>>
    {
        public override IEnumerable<IPlayerAction> ReadJson(JsonReader reader, Type objectType, IEnumerable<IPlayerAction> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, IEnumerable<IPlayerAction> value, JsonSerializer serializer)
        {
            var jsonActions = new JArray();
            foreach (var action in value)
            {
                var jObjectAction = new JObject
                {
                    ["type"] = action.GetType().FullName,
                    ["object"] = JObject.FromObject(action)
                };
                jsonActions.Add(jObjectAction);
            }
            jsonActions.WriteTo(writer);
        }
    }
}
