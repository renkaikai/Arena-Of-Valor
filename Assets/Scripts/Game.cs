using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game
{
    private static Game _instance;
    private static string databaseResourcePath = "Database/Database";
    private Game() {
        // 加载数据库资源
        database = Resources.Load(databaseResourcePath) as Database;
        if(database == null)
        {
            Debug.Log("Warning! Load database failed!");
        }
    }

    public static Game Instance
    {
        get
        {  
            if(_instance == null)
            {
                _instance = new Game();
            }          
            return _instance;
        }
        
    }
    /// <summary>
    /// 物品/技能/英雄 属性数据库
    /// </summary>
    public Database database;
    /// <summary>
    /// 存放当前游戏模式
    /// </summary>
    public GameMode gameMode;
    /// <summary>
    /// 游戏状态
    /// </summary>
    public GameState gameState;
    /// <summary>
    /// 当前游戏玩家
    /// </summary>
    public Player player;
    /// <summary>
    /// 双方战队英雄编号
    /// </summary>
    public int[,] teamHeroIds;
    /// <summary>
    /// 战队规模
    /// </summary>
    public int teamSize;
    /// <summary>
    /// 难度级别
    /// </summary>
    public int difficultLevel;
    
    
}
