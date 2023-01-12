using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WrongTurn.StateManagement;
using WrongTurn.StateManagement.Actions.Base;

public class ServerProxy : IServerProxy
{
    private readonly string _serverUrl;
    private readonly string _playerControllerPath = "/api/PlayerState/";
    private readonly string _saveStatePath = "save";
    private readonly string _unlockAchievementPath = "unlock";

    public ServerProxy(string serverUrl)
    {
        _serverUrl = serverUrl;
    }

    public async Task<PlayerState?> GetByPlayerId(Guid playerId)
    {
        var url = _serverUrl + _playerControllerPath + playerId.ToString();
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        var response = await client.SendAsync(request);
        if (!response.IsSuccessStatusCode) return null;
        var jsonPlayerState = await response.Content.ReadAsStringAsync();
        var jObject = JObject.Parse(jsonPlayerState);
        return jObject.ToObject<PlayerState>();
    }

    public async Task<PlayerState?> SaveState(Guid playerId, PlayerState playerState, IEnumerable<IPlayerAction> actions)
    {
        var url = _serverUrl + _playerControllerPath + _saveStatePath;
        var client = new HttpClient();
        var model = new SaveStateModel
        {
            PlayerId = playerId,
            PlayerState = playerState,
            Actions = actions
        };
        var requestBody = JObject.FromObject(model).ToString();
        var content = new StringContent(requestBody, Encoding.UTF8, "application/json");
        var response = await client.PostAsync(url, content);
        if (!response.IsSuccessStatusCode) return null;
        var jsonPlayerState = await response.Content.ReadAsStringAsync();
        if (string.IsNullOrEmpty(jsonPlayerState)) return null;
        return JObject.Parse(jsonPlayerState).ToObject<PlayerState>();
    }

    public async Task<bool> UnlockAchievement(Guid playerId, string achievementId)
    {
        var url = _serverUrl + _playerControllerPath + _unlockAchievementPath;
        var client = new HttpClient();
        var model = new UnlockAchievementModel
        {
            PlayerId = playerId,
            AchievementId = achievementId
        };
        var json = JsonConvert.SerializeObject(model);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PutAsync(url, content);
        return response.IsSuccessStatusCode;
    }
}
