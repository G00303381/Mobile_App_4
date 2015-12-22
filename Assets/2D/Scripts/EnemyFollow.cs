using UnityEngine;
using System.Collections;

public class EnemyFollow : MonoBehaviour
{
    public float moveSpeed = 2f;        // The speed the enemy moves at.
    public int HP = 2;                  // How many times the enemy can be hit before it dies.
    public GameObject hundredPointsUI;  // A prefab of 100 that appears when the enemy dies.

    private SpriteRenderer ren;         // Reference to the sprite renderer.
    private Transform frontCheck;       // Reference to the position of the gameobject used for checking if something is in front.
    private bool dead = false;          // Whether or not the enemy is dead.
    private Score score;                // Reference to the Score script.


    void Awake()
    {
        score = GameObject.Find("Score").GetComponent<Score>();
    }

    void FixedUpdate()
    {

        if (HP <= 0 && !dead)
        {
            Death();
        }
    }

    public void Hurt()
    {
        HP--;
    }

    void Death()
    {
        SpriteRenderer[] otherRenderers = GetComponentsInChildren<SpriteRenderer>();

        foreach (SpriteRenderer s in otherRenderers)
        {
            s.enabled = false;
        }

        //ren.enabled = true;
        score.score += 100;
        dead = true;
        GameManager.KillEnemy(this);
        //Destroy(gameObject, 0.2f);

        Vector3 scoreUIPos;
        scoreUIPos = transform.position;
        scoreUIPos.y += 1.5f;

        Instantiate(hundredPointsUI, scoreUIPos, Quaternion.identity);
    }
}
