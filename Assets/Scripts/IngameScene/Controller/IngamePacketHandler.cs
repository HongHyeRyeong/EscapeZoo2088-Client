﻿using CommonProtocol;
using EnumDef;
using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

public class IngamePacketHandler : MonoBehaviour
{
    public static bool isTest = false;

    #region Send

    public void SendEnterGame()
    {
        if (isTest)
        {
            GlobalData.playerInfos = new List<PlayerInfos>() { new PlayerInfos() { animal = 1, userId = "1", mbti = "isfj" } };
            GlobalData.myId = "1";
            IngameScene.Instance.EnterGame();
            return;
        }

        var req = new IngameProcotol();
        IngameProcotol res = null;

        string jsondata = JsonConvert.SerializeObject(req);
        StartCoroutine(SendProtocolManager.Instance.CoSendLambdaReq(jsondata, "EnterIngame", (responseString) =>
        {
            res = JsonConvert.DeserializeObject<IngameProcotol>(responseString);
            RecvEnterGame(res);
        }));
    }

    public void SendStartRound(bool clearRound = false)
    {
        if (GlobalData.roundIndex + 1 == GlobalData.roundMax)
        {
            SendLastRound();
            return;
        }

        if (isTest)
        {
            GlobalData.roundIndex = GlobalData.roundIndex + 1;
            GlobalData.enemyRoundIndex = 1;
            GlobalData.sunriseTime = 3;
            IngameScene.Instance.LoadRound();
            return;
        }

        var req = new IngameProcotol();
        IngameProcotol res = null;

        if (clearRound)
            GlobalData.roundIndex++;
        req.preRoundNum = GlobalData.roundIndex;

        string jsondata = JsonConvert.SerializeObject(req);
        StartCoroutine(SendProtocolManager.Instance.CoSendLambdaReq(jsondata, "StartGame", (responseString) =>
        {
            res = JsonConvert.DeserializeObject<IngameProcotol>(responseString);
            RecvStartRound(res);
        }, !clearRound));
    }

    private void StartRound()
    {
        IngameScene.Instance.StartRound();
    }

    private bool isSendRestart = false;

    public void SendRestartRound()
    {
        if (isSendRestart)
            return;

        if (isTest)
        {
            Invoke("StartRound", 1);
            return;
        }

        var req = new IngameProcotol();
        IngameProcotol res = null;
        isSendRestart = true;

        req.currentRoundNum = GlobalData.roundRetryCount + GlobalData.roundIndex + 1;

        string jsondata = JsonConvert.SerializeObject(req);
        StartCoroutine(SendProtocolManager.Instance.CoSendLambdaReq(jsondata, "RestartGame", (responseString) =>
        {
            res = JsonConvert.DeserializeObject<IngameProcotol>(responseString);
            RecvRestartRound(res);
            isSendRestart = false;
        }));
    }

    public void SendLastRound()
    {
        if (isTest)
        {
            GlobalData.isWinner = true;
            IngameScene.Instance.ClearGame();
            return;
        }

        var req = new IngameProcotol();
        IngameProcotol res = null;

        string jsondata = JsonConvert.SerializeObject(req);
        StartCoroutine(SendProtocolManager.Instance.CoSendLambdaReq(jsondata, "LastGame", (responseString) =>
        {
            res = JsonConvert.DeserializeObject<IngameProcotol>(responseString);
            RecvLastRound(res);
        }));
    }

    public void SendMatchResult()
    {
        var req = new IngameProcotol();
        IngameProcotol res = null;

        string jsondata = JsonConvert.SerializeObject(req);
        StartCoroutine(SendProtocolManager.Instance.CoSendLambdaReq(jsondata, "MatchResult", (responseString) =>
        {
            res = JsonConvert.DeserializeObject<IngameProcotol>(responseString);
            RecvMatchResult(res);
        }));
    }

    public void SendExitGame()
    {
        var req = new IngameProcotol();

        req.teamUserCount = GlobalData.playingUserCount;

        IngameProcotol res = null;

        string jsondata = JsonConvert.SerializeObject(req);
        StartCoroutine(SendProtocolManager.Instance.CoSendLambdaReq(jsondata, "ExitGame", (responseString) =>
        {
            res = JsonConvert.DeserializeObject<IngameProcotol>(responseString);
            RecvExitGame(res);
        }));
    }

    #endregion

    #region Recv

    public void RecvEnterGame(IngameProcotol res)
    {
        if (res.ResponseType == ResponseType.Success)
        {
            GlobalData.playerInfos = res.playerInfos;
            GlobalData.playingUserCount = GlobalData.playerInfos.Count;
            IngameScene.Instance.EnterGame();
        }
        else
            Debug.LogAssertion($"ResEnterGame.ResponseType != Success");
    }

    public void RecvStartRound(IngameProcotol res)
    {
        if (res.ResponseType == ResponseType.Success)
        {
            GlobalData.roundList = res.roundList;
            GlobalData.roundIndex = res.currentRoundNum - 1;
            GlobalData.enemyRoundIndex = res.enemyRoundNum - 1;
            GlobalData.sunriseTime = res.sunriseTime;
            IngameScene.Instance.LoadRound();
        }
        else
            Debug.LogAssertion($"ResStartGame.ResponseType != Success");
    }

    public void RecvRestartRound(IngameProcotol res)
    {
        if (res.ResponseType == ResponseType.Success)
        {
            GlobalData.roundRetryCount = res.currentRoundNum - (GlobalData.roundIndex + 1);
            GlobalData.enemyRoundIndex = res.enemyRoundNum - 1;
            GlobalData.sunriseTime = res.sunriseTime;
            IngameScene.Instance.StartRound();
        }
        else
            Debug.LogAssertion($"ResReStartGame.ResponseType != Success");
    }

    public void RecvLastRound(IngameProcotol res)
    {
        if (res.ResponseType == ResponseType.Success)
        {
            GlobalData.isWinner = res.isWinner;
            IngameScene.Instance.ClearGame();
            SendMatchResult();
        }
        else
            Debug.LogAssertion($"ResLastRound.ResponseType != Success");
    }

    public void RecvMatchResult(IngameProcotol res)
    {
        if (res.ResponseType == ResponseType.Success)
        {
            GlobalData.myScore = res.score;
        }
        else
            Debug.LogAssertion($"ResMatchResult.ResponseType != Success");
    }

    public void RecvExitGame(IngameProcotol res)
    {
        if (res.ResponseType == ResponseType.Success)
        {
            Debug.LogWarning("Lambda Server Disconnect");
            IngameScene.Instance.DisConnectP2PServer();
        }
        else
            Debug.LogAssertion($"ResExitGame.ResponseType != Success");
    }

    #endregion
}