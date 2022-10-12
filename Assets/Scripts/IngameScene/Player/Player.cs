﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumDef;

public class Player : MonoBehaviour
{
    private PlayerInfo _info;

    public bool IsMine
    {
        get
        {
            if (_info != null)
                return _info.Id == GlobalData.myId;
            return false;
        }
    }
    public bool HasKey
    {
        get
        {
            return GetComponentInChildren<RoundObjKey>() != null;
        }
    }

    void Start()
    {
        IngamePlayerController.Instance.AddPlayer(this);

        List<PlayerInfo> playerInfos = GlobalData.playerInfos;
        foreach (PlayerInfo info in playerInfos)
        {
            if (info.Id == GlobalData.myId)
            {
                _info = info;
                return;
            }
        }
    }

    public void LoadRound(Vector3 startPos, Transform parent)
    {
        gameObject.SetActive(true);

        transform.position = startPos;
        transform.parent = parent;
    }

    void OnDestroy()
    {
        IngamePlayerController.Instance?.RemovePlayer(this);
    }
}