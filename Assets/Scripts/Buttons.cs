using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {

	public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		ScoreSystem.points = 0;
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("menu");
		ScoreSystem.points = 0;
    }
    public void PLay()
    {
        SceneManager.LoadScene(1);
		ScoreSystem.points = 0;
    }
    public void Quit()
    {
		ScoreSystem.points = 0;
		Application.Quit ();
    }
}
