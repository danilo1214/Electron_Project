using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Using this is script as players main Class
/// </summary>
public class MovementScript : MonoBehaviour {
    public static bool PlayerDeath = false;
    public GameObject DeathMenu;
    CharacterController cctrl;
	public float Speed;
	static public float ForwardSpeed;
	public float InitialSpeed = 7f;
    void Start () {
		cctrl = GetComponent<CharacterController> ();
		ForwardSpeed = InitialSpeed;
        PlayerDeath = false;
}

	void Update () {
		if (PlayerDeath == true)
		{
			Die ();
		}
		MoveElectron ();
		GoForward ();
		if(Input.GetKeyDown(KeyCode.F11)){
			ForwardSpeed = 40;
		}

	}

	void MoveElectron(){
		Vector3 direction = new Vector3 (Input.GetAxis ("Mouse X"), Input.GetAxis ("Mouse Y"), 0f);
		//Vector3 newPos = Vector3.Lerp (transform.position,direction * Speed * Time.deltaTime, 2f);
		//cctrl.Move (newPos);
		cctrl.Move(direction * Speed * Time.deltaTime);
	}
	void GoForward(){
        //Speed += ScoreSystem.points;
		cctrl.Move (Vector3.forward * ForwardSpeed * Time.deltaTime);
	}

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "pipe") // KILL THE PLAYER WHEN TOUCHING WALLS
        {                                   //Walls need tag of "pipe" to work

            
            //deathscreen
            //stop camera
            //destroy this gameobject
			if(ScoreSystem.points > 0){
				ScoreSystem.points -= 1;
			}
        }
    }
    public static void SpeedUp()
    {
		ForwardSpeed += 0.1f;
    }
	public void Die(){
		DeathMenu.SetActive(true);
		this.gameObject.SetActive(false);
		if(ScoreSystem.points > ScoreSystem.highScore){
			PlayerPrefs.SetInt("highScore",ScoreSystem.points);
			ScoreSystem.highScore = ScoreSystem.points;
		}
		return;
	}
}
