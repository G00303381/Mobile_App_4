using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

    public int score = 0;

    public int highScore;

    private string highScoreKey = "highScore";

    private PlayerHealth player;
    //private int prevScore = 0;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        GetComponent<GUIText>().text = "Score: " + score;

        if(highScore < score)
        {
            highScore = score;
            GetComponent<GUIText>().text = "HighScore: " + highScore;
            PlayerPrefs.SetInt(highScoreKey, highScore);
            PlayerPrefs.Save();
        }
        //prevScore = score;
	}
}
