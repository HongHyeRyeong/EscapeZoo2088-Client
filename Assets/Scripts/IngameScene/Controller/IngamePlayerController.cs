﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumDef;
using EuNet.Unity;

public class IngamePlayerController : SceneSingleton<IngamePlayerController>
{
    [SerializeField] Transform _clearPlayer;

    private List<Player> _playerList = new List<Player>();

    private bool _isCreateComplete = false;
    public bool CreateComplete { get { return _isCreateComplete; } }

    public void CreatePlayer()
    {
        P2PInGameManager.Instance.CreateMyPlayer();

        _isCreateComplete = true;
    }

    public void LoadRound()
    {
        _playerList.Sort();
        PlayerResetPreStep();
        List<Vector3> spawn = IngameScene.Instance.MapController.GetPlayerSpawn();
        for (int i = 0; i < _playerList.Count; ++i)
            _playerList[i].LoadRound(spawn[i], transform);
        Invoke("PlayerResetPostStep", 0.15f);
    }

    public void StartRound()
    {
        LoadRound();
    }

    public void ClearGame()
    {
        gameObject.SetActive(false);
    }

    public void AddPlayer(Player p)
    {
        _playerList.Add(p);
    }

    public void RemovePlayer(Player p)
    {
        if (_playerList.Contains(p))
            _playerList.Remove(p);
    }

    public Player GetMyPlayer()
    {
        foreach (Player player in _playerList)
            if (player.IsMine)
                return player;
        return null;
    }

    public List<Player> GetPlayerList()
    {
        return _playerList;
    }

    public Vector3 GetClearPlayerPos()
    {
        return _clearPlayer.position;
    }

    void PlayerResetPreStep()
    {
        foreach(var p in _playerList)
        {
            p.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }

    void PlayerResetPostStep()
    {
        foreach (var p in _playerList)
        {
            p.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
