using System;
using UnityEngine;


public static class MonoBehaviourExtentions
{
    public static GameState GetGameState(this MonoBehaviour behaviour)
    {
        return Game.Instance.gameState;
    }

    public static PlayerController GetPlayerController(this MonoBehaviour behaviour, int index)
    {
        return Game.Instance.gameMode.GetPlayerController(index);
    }

    public static AIController GetAIController(this MonoBehaviour behaviour, int index)
    {
        return Game.Instance.gameMode.GetAIController(index);
    }
}