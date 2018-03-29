using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {
    [HideInInspector]
    public int[] teamKills = new int[2];

    void Awake()
    {
        Game.Instance.gameState = this;
    }
}
