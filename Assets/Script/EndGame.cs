using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class EndGame : MonoBehaviour
{

    int highscore = 0;

    void Start()
    {
        highscore = PlayerPrefs.GetInt("HighScore");
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = 0;
        if (Time.timeScale == 0)
        {
            GameObject.Find("Score").GetComponent<Text>().text = "Score: " + PlayerMovement.score; if (PlayerMovement.score > highscore)
            {
                highscore = PlayerMovement.score;
                PlayerPrefs.SetInt("HighScore", highscore);
            }
            GameObject.Find("Highscore").GetComponent<Text>().text = "Highscore: " + highscore;
            GameObject.Find("ScorePlay").GetComponent<Text>().text = "";
            GameObject.Find("Restart").GetComponent<Text>().text = "Press \"R\" to restart\nPress \"ESC\" to exit";
            if (Input.GetKeyUp("r"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Time.timeScale = 1;
                PlayerMovement.score = 0;
            }
            if (Input.GetKeyUp("escape"))
            {
                Application.Quit();
            }
        }
        else
        {
            if (Input.GetKeyUp("space"))
            {
                GameObject.Find("Start").GetComponent<Text>().text = "";
                Destroy(GameObject.Find("menu-PSD"));
            }
            GameObject.Find("Score").GetComponent<Text>().text = "";
            GameObject.Find("Restart").GetComponent<Text>().text = "";
            GameObject.Find("Highscore").GetComponent<Text>().text = "";
            GameObject.Find("ScorePlay").GetComponent<Text>().text = PlayerMovement.score + "";
        }
    }
}
