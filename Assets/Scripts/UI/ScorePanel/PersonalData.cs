using UnityEngine;
using UnityEngine.UI;

public class PersonalData : MonoBehaviour {
    public Text kills;
    public Text deaths;
    public Text assists;

    private PlayerState playerState;

    void Start()
    {
        // _gameState = new GameState();
        // _gameState.personalKills = 1;
        playerState = this.GetPlayerController(0).playerState;
    }
	// Update is called once per frame
	void Update () {

        kills.text = playerState.kills.ToString();
        deaths.text = playerState.deaths.ToString();
        assists.text = playerState.assits.ToString();
	}
}
