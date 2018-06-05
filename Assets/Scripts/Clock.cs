using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Clock : MonoBehaviour {

	void Start () {
		Time.timeScale = 1;
	}
	
	void Update () {
        Debug.Log("nigger");
	}
	void OnTriggerEnter(Collider col){
		if(col.name == "Player"){
			Time.timeScale = 0.5f;
			StartCoroutine ("NormalTime");
			GameObject.Find ("Canvas/SlowTime").GetComponent<Image>().enabled = true;
		}
	}
	IEnumerator NormalTime(){
		yield return new WaitForSeconds (4f);
		GameObject.Find ("Canvas/SlowTime").GetComponent<Image> ().enabled = false;
		Time.timeScale = 1;
	}

}
