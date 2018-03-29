using UnityEngine;
using UnityEngine.UI;

public class GameTime : MonoBehaviour {

    int min = 0;
    int sec = 0;

    public Text textMin;
    public Text textSec;
    
    // Use this for initialization
    void Start()
    {
        Invoke("Timer", 1.0000f);
    }
    // Timer
    void Timer()
    {
        sec++;
        if (sec >= 60)
        {
            sec = 0;
            min++;
        }
        textSec.text = sec >= 10 ? sec.ToString() : "0" + sec;
        textMin.text = min > 9 ? min.ToString() : "0" + min;
        Invoke("Timer", 1.0000f);
    }
}
