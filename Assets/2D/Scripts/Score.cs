using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	
	// Update is called once per frame
	void Update ()
    {
        GetComponent<GUIText>().text = PlayerPrefs.GetInt("Score").ToString();
        //Debug.Log("Current Score: " + currScore);

	}
}
