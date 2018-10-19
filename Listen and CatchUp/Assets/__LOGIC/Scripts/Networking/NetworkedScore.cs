using GameSparks.Api.Responses;
using GameSparks.Core;
using System;
using UnityEngine;

public class NetworkedScore : SingletonBehaviour<NetworkedScore>
{
    public string AccountLogin = "Joe";
    public string AccountPassword = "";
    public string GameName;

    public void PushScore(string nickName, int score, Action<LogEventResponse> onFinished = null)
    {
        var gameSparksConnection = GameSparksConnection.Instance;
        if (!gameSparksConnection.LoggedIn)
        {
            gameSparksConnection.Login(AccountLogin, AccountPassword, response =>
            {
                if (!gameSparksConnection.LoggedIn)
                    PushScoreInternal(nickName, score, onFinished);

            });
            return;
        }
        PushScoreInternal(nickName, score, onFinished);
    }

    private void PushScoreInternal(string nickName, int score, Action<LogEventResponse> onFinished)
    {
        GameSparksConnection.Instance.SendEvent("PushScore", scoreEvent =>
             {
                 scoreEvent.SetEventAttribute("GameName", GameName).SetEventAttribute("Nickname", nickName)
                     .SetEventAttribute("Score", score);
             }, onFinished);
    }

    public void GetScores(int count, Action<GSData> onFinished)
    {
        GameSparksConnection.Instance.SendEvent("GetScores", scoreEvent =>
             {
                 scoreEvent.SetEventAttribute("GameName", GameName).SetEventAttribute("Count", count);
             }, response =>
         {
             onFinished.Invoke(response.BaseData);
         });
    }
}
