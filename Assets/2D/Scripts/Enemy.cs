using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f;
    public int HP = 2;
    public Sprite deadEnemy;
    public Sprite damagedEnemy;
    public AudioClip[] deathClips;
    public GameObject hundredPointsUI;
    public float deathSpinMin = -100f;
    public float deathSpinMax = 100f;

    private Transform frontCheck;
    private bool dead = false;
    private Score score;

    void Awake()
    {
        frontCheck = transform.Find("frontCheck").transform;
        score = GameObject.Find("Score").GetComponent<Score>();
    }

    void FixedUpdate()
    {
        // Create an array of all the colliders in front of the enemy.
        Collider2D[] frontHits = Physics2D.OverlapPointAll(frontCheck.position, 1);

        // Check each of the colliders.
        foreach (Collider2D c in frontHits)
        {
            // If any of the colliders is an Obstacle...
            if (c.tag == "Obstacle")
            {
                // ... Flip the enemy and stop checking the other colliders.
                Flip();
                break;
            }

        }
     
        GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x * moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

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
        // Increase the score by 100 points
        score.score += 100;

        // Set dead to true.
        dead = true;

        GetComponent<Rigidbody2D>().AddTorque(Random.Range(deathSpinMin, deathSpinMax));

        Collider2D[] cols = GetComponents<Collider2D>();
        foreach (Collider2D c in cols)
        {
            c.isTrigger = true;
        }

        Vector3 scorePos;
        scorePos = transform.position;
        scorePos.y += 1.5f;

        Instantiate(hundredPointsUI, scorePos, Quaternion.identity);
    }


    public void Flip()
    {
        // Multiply the x component of localScale by -1.
        Vector3 enemyScale = transform.localScale;
        enemyScale.x *= -1;
        transform.localScale = enemyScale;
    }
}
