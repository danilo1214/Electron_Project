using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour {
    public float timer = 0;
    static public int points = 0;
	public static int highScore;

    public Text Timer_text;
    public Text Points_text;
	public Text HighScore_text;
    int time_need_for_speed_up = 10;
    // Use this for initialization
    void Start () {
		highScore = PlayerPrefs.GetInt ("highScore",highScore);
	}
	
	// Update is called once per frame
	void Update () {
        if (MovementScript.PlayerDeath == false)
        {
            timer += Time.deltaTime;
            if (timer > time_need_for_speed_up)
            {
                time_need_for_speed_up += 10;
				MovementScript.ForwardSpeed += 0.1f;
            }
            //update Text UI
            Timer_text.text = "Timer: " + Mathf.Round(timer) + "s";
            Points_text.text = "Points: " + points;
			HighScore_text.text = "High Score: " + highScore;
        }
		if(Input.GetKeyDown(KeyCode.F10)){
			highScore = 0;
			PlayerPrefs.SetInt ("highScore",0);
		}




    }
    static public void AddPoint()
    {
        points++;
        //update text 
        

    }
}
