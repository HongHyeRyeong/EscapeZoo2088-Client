﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameMapController : MonoBehaviour
{
    [SerializeField] Transform _parent;

    private List<GameObject> _roundList;

    private bool _isCreateComplete = false;
    public bool CreateComplete { get { return _isCreateComplete; } }

    public void CreateMapAndRound(int[] roundList)
    {
        int mapIndex = GlobalData.mapIndex;

        // 맵 로딩
        Instantiate(Resources.Load<GameObject>("Map/Map_" + mapIndex), _parent);

        // 라운드 생성
        _roundList = new List<GameObject>();
        foreach (int round in roundList)
        {
            _roundList.Add(Instantiate(Resources.Load<GameObject>("Round/Round_" + round), _parent));
            // 라운드 맵 셋팅 필요
        }

        _isCreateComplete = true;
    }

    public void OnLoadNextRound(int nextRound)
    {
        foreach (var round in _roundList)
            round.SetActive(false);
        _roundList[nextRound].SetActive(true);
    }
}
