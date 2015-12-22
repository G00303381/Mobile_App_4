using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	public void LoadScene(int level)
	{	//load the level (1) whne start game is pressed
		Application.LoadLevel (level);
	}
}
