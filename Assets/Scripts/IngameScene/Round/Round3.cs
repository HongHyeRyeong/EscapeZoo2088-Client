﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Round3 : Round
{
    [Header("Round 3")]
    [Space(10)]
    [SerializeField] RoundObjKey _key;
    [SerializeField] RoundObjClear _clear;

    #region Base Round

    public override void LoadRound()
    {
        base.LoadRound();

        _clear.LoadRound(this);
    }

    public override void StartRound()
    {
        base.StartRound();

        _key.StartRound();
    }

    public override void SendClearRound()
    {
        if (_playerController.GetMyPlayer().HasKey)
            base.SendClearRound();
    }

    #endregion
}