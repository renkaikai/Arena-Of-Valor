using UnityEngine;
using UnityEngine.UI;

public class TeamData : MonoBehaviour {

    public Text team0Kills;
    public Text team1Kills;

    private GameState _gameState;

    void Start()
    {
        //_gameState = new GameState();
        //_gameState.teamKills[0] = 5;
        //_gameState.teamKills[1] = 10;
       _gameState = this.GetGameState();
    }

    void Update()
    {
        team0Kills.text = _gameState.teamKills[0].ToString();
        team1Kills.text = _gameState.teamKills[1].ToString();
    }
}
