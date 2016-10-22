using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class EndGame : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        if (Time.timeScale == 0)
        {
            GameObject.Find("Score").GetComponent<Text>().text = "Score: " + PlayerMovement.score;
            GameObject.Find("ScorePlay").GetComponent<Text>().text = "";
            GameObject.Find("Restart").GetComponent<Text>().text = "Press \"R\" to restart";
            if (Input.GetKeyUp("r")){
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Time.timeScale = 1;
                PlayerMovement.score = 0;
            }
        }
        else
        {
            GameObject.Find("ScorePlay").GetComponent<Text>().text = PlayerMovement.score + "";
        }
	}
}
