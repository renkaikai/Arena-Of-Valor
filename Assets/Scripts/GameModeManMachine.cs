using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeManMachine : GameMode
{
    /// <summary>
    /// 机器 AI 控制器
    /// </summary>
    public GameObject heroAIController;    
    /// <summary>
    /// 存放玩家控制器对象
    /// </summary>
    private Controller[,] controllers;

    // Use this for initialization
    void Awake()
    {
        Game.Instance.gameMode = this;
        SpawnGameObjects();        
    }

    void SpawnGameObjects()
    {        
        // 角色起始位置
        PlayerStart[] playerStarts;        
        // 创建水晶
        GameObject CrystalPositions = GameObject.Find("CrystalPositions");
        playerStarts = CrystalPositions.GetComponentsInChildren<PlayerStart>();
        SpawnNonHeroes(crystal, playerStarts, Game.Instance.database.crystalAttributes);
        // 创建防御塔
        GameObject GuardTowerPositions = GameObject.Find("GuardTowerPositions");
        playerStarts = GuardTowerPositions.GetComponentsInChildren<PlayerStart>();
        SpawnNonHeroes(guardTower, playerStarts, Game.Instance.database.guardTowerAttributes);
        // 创建泉水
        GameObject BirthPlacePositions = GameObject.Find("BirthPlacePositions");
        playerStarts = BirthPlacePositions.GetComponentsInChildren<PlayerStart>();
        SpawnNonHeroes(birthPlace, playerStarts, Game.Instance.database.birthPlaceAttributes);
        // 创建英雄 (英雄位置和泉水位置相同)
        SpawnHeroes(playerStarts);
    }

    void SpawnNonHeroes(GameObject prefab, PlayerStart[] playerStarts, List<AttributeValue> attrValues)
    {
        GameObject go;
        Controller c;
        PlayerState ps;
        foreach(PlayerStart playerStart in playerStarts)
        {
            go = Instantiate(prefab, playerStart.transform.position, playerStart.transform.rotation);
            ps = go.AddComponent<PlayerState>();
            c = go.GetComponent<Controller>();
            c.teamIndex = playerStart.teamIndex;
            c.playerState = ps;
            if (attrValues != null)
            {
                ps.attributes = new AttributeValue[attrValues.Count];
                ps.maxAttributes = new AttributeValue[attrValues.Count];
                for (int i = 0; i < attrValues.Count; i++)
                {
                    ps.attributes[i] = attrValues[i].Clone();
                    ps.maxAttributes[i] = attrValues[i].Clone();
                }
            }
        }
    } 
    
    void SpawnHeroes(PlayerStart[] playerStarts)
    {
        // 读取战队规模
        teamSize = Game.Instance.teamSize;
        if (teamSize == 0)// Just for test
        {
            teamSize = 1;
        }
        // 读取英雄编号
        heroIds = Game.Instance.teamHeroIds;
        if (heroIds == null)// Just for test
        {
            heroIds = new int[,] { { 0 }, { 1 } };
        }              
        // 分配玩家位置
        Transform[,] positions = new Transform[2, teamSize];
        int i = 0, j = 0;
        foreach (PlayerStart playerStart in playerStarts)
        {
            if (playerStart.teamIndex == 0)
            {
                positions[0, i++] = playerStart.transform;
            }
            else
            {
                positions[1, j++] = playerStart.transform;
            }
        }
        // 创建英雄角色和控制器对象
        GameObject[] arr = new GameObject[2] { playerController, heroAIController };
        HeroCharacter character;     
        Hero hero;
        controllers = new Controller[2, teamSize];     
        for (i = 0; i < 2; i++)
        {
            for (j = 0; j < teamSize; j++)
            {
                hero = Game.Instance.database.GetHeroById(heroIds[i, j]);
                character = GameObject.Instantiate(hero.heroPrefab, positions[i, j].position, positions[i, j].rotation).GetComponent<HeroCharacter>();
                character.hero = Instantiate(hero);
                // Adjust architecture 
                // Add controler component on to character
                if (i == 0)
                {
                    controllers[i, j] = character.gameObject.AddComponent<PlayerController>();
                }
                else
                {
                    controllers[i, j] = character.gameObject.AddComponent<HeroAIControllerEasy>();
                }
                // controllers[i, j] = GameObject.Instantiate(arr[i]).GetComponent<Controller>();
                controllers[i, j].teamIndex = i;
                controllers[i, j].playerState = SpawnPlayerState(character.hero);
                controllers[i, j].Possess(character);
            }
        }
        // 存储玩家控制器
        _controllers = new PlayerController[teamSize];
        for (i = 0; i < teamSize; i++)
        {
            _controllers[i] = (PlayerController)controllers[0, i];
        }
        // 存储AI控制器对象
        _aiControllers = new AIController[teamSize];
        for (i = 0; i < teamSize; i++)
        {
            _aiControllers[i] = (AIController)controllers[1, i];
        }
    }  
    
    PlayerState SpawnPlayerState(Hero hero)
    {
        PlayerState ps = Instantiate(playerState).GetComponent<PlayerState>();
        // 设置最大属性值列表
        ps.maxAttributes = hero.attributes;
        // 克隆当前属性值列表
        int len = hero.attributes.Length;
        ps.attributes = new AttributeValue[len];        
        for(int i = 0; i < len; i++)
        {
            ps.attributes[i] = hero.attributes[i].Clone();
        }
        //
        return ps;
    } 
}

