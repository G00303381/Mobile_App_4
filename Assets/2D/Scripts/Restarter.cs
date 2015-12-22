using UnityEngine;

namespace UnitySampleAssets._2D
{
    public class Restarter : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                //GameObject.FindGameObjectWithTag("MainCamera").GetComponent <Camera2DFollow>().enabled = false;

                if (GameObject.FindGameObjectWithTag("HealthBar").activeSelf)
                {
                    GameObject.FindGameObjectWithTag("HealthBar").SetActive(false); 
                }
              
                Destroy(other.gameObject);
                GameManager.gameOver = true;
                //Application.LoadLevel(Application.loadedLevelName);
            }

            else
            {
                Destroy(other.gameObject);
            }
        }
    }
}
