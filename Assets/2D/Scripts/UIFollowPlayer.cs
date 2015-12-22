using UnityEngine;
using System.Collections;

public class UIFollowPlayer : MonoBehaviour {

    public Vector3 offset;

    private Transform playerPrefab;

    // Use this for initialization
	void Awake()
    {
        playerPrefab = GameObject.FindGameObjectWithTag("Player").transform;

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (playerPrefab != null)
        {
            transform.position = playerPrefab.position + offset;
        }
	}
}
