using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 游戏模式
/// </summary>
public class GameMode : MonoBehaviour {    
    /// <summary>
    /// 玩家控制器对象Prefab
    /// </summary>
    public GameObject playerController;
    /// <summary>
    /// 玩家状态对象Prefab
    /// </summary>
    public GameObject playerState;
    /// <summary>
    /// 防御塔对象Prefab
    /// </summary>     
    public GameObject guardTower;
    /// <summary>
    /// 水晶对象Prefab
    /// </summary>
    public GameObject crystal;
    /// <summary>
    /// 泉水(玩家出生地)对象Prefab
    /// </summary>
    public GameObject birthPlace;
    /// <summary>
    /// 战队规模
    /// </summary>
    [HideInInspector]
    public int teamSize;
    /// <summary>
    /// 英雄编号
    /// </summary>
    [HideInInspector]
    public int[,] heroIds;
    /// <summary>
    /// 存放所有游戏玩家控制器对象
    /// </summary>
    protected PlayerController[] _controllers;
    /// <summary>
    /// 存放游戏中英雄角色AI控制器对象
    /// </summary>
    protected AIController[] _aiControllers;
    
    void Awake()
    {        
        Game.Instance.gameMode = this;
    }

    public PlayerController GetPlayerController(int index)
    {
        if(_controllers != null&& index < _controllers.Length)
        {
            return _controllers[index];
        }
        return null;
    }

    public AIController GetAIController(int index)
    {
        if (_aiControllers != null && index < _aiControllers.Length)
        {
            return _aiControllers[index];
        }
        return null;
    }
}
