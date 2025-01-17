using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager gm;
    public Transform player;
    public Transform spawnPoint;
    public float spawnDelay = 2f;
    public Transform spawnParticle;
    public static bool gameOver = false;

    public GUIText GameOverText;
    public GUIText FinalScoreText;
    public GUIText ReplayText;
    public GUIText MainMenuText;
    public GUIText HighScoreText;
    public GUIText LeaderboardText;

    private Score score;

    void Awake()
    {
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        }

        score = GameObject.Find("Score").GetComponent<Score>();

        Initialize();
    }

    void Update()
    {
        if (gameOver == true)
        {
            GameOverText.text = "GAME OVER";            //Show GUI GameOver
            FinalScoreText.text = "FINAL SCORE: " + PlayerPrefs.GetInt("Score").ToString();           //Show GUI FinalScore
            ReplayText.text = "PRESS R TO REPLAY";      //Show GUI Replay
            MainMenuText.text = "PRESS M TO RETURN TO MENU";
            LeaderboardText.text = "PRESS L TO SUBMIT YOUR SCORE";

            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                Application.LoadLevel("Main_Menu");
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                Application.LoadLevel("Main_Leaderboard");
            }

        }
    }

    private void Initialize()
    {
        //reset game values on intialisation
        gameOver = false;
        GameOverText.text = "";
        FinalScoreText.text = "";           
        ReplayText.text = "";
        MainMenuText.text = "";
    }

    public static void KillPlayer(PlayerHealth player)
    {
        Destroy(player.gameObject);
        //gm.StartCoroutine(gm.RespawnPlayer());
    }

    public static void KillEnemy(EnemyFollow enemy)
    {
        Destroy(enemy.gameObject);
    }

    public static void KillEnemy(Enemy enemy)
    {
        Destroy(enemy.gameObject);
    }



    //public IEnumerator RespawnPlayer()
    //{
    //    GetComponent<AudioSource>().Play();
    //    yield return new WaitForSeconds(spawnDelay);
    //    Instantiate(player, spawnPoint.position, spawnPoint.rotation);
    //    Transform clone = (Transform)Instantiate(spawnParticle, spawnPoint.position, spawnPoint.rotation);
    //    Destroy(clone.gameObject, 3f);

    //}

}
