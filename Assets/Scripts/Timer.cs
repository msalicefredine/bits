using UnityEngine;
using System.Collections;
using System;
using System.Reflection;

public class Timer : MonoBehaviour {

	//private float levelTime;
	private float startTime;
	public GUIStyle style;
	// Use this for initialization
	void Start () {
		startTime = Time.deltaTime;
		//levelTime = 0;
		//ALICE: Here is the variable you can work with: GameState.currentTime;
	}
	
	// Update is called once per frame
	void Update () {

		//levelTime = Time.deltaTime - startTime;
		GameState.currentTime = Time.deltaTime - startTime;
		/*levelTime -= Time.deltaTime;
		if (levelTime < 20) {
			style.normal.textColor = Color.yellow;
		}
		if (levelTime < 10) {
			style.normal.textColor = Color.red;
		}

		if (levelTime <= 0) {
			// end level, display menu to restart etc.
		}*/
	
	}

	void OnGUI () {
		int minutes = (int) GameState.currentTime / 60; 
		int seconds = (int) GameState.currentTime % 60; 
		// int fraction = (int) (levelTime * 100) % 100;

		string timeText = String.Format ("{0:00}:{1:00}", minutes, seconds); 
		// GUI.Label (new Rect (Screen.width*0.9f, Screen.height*0.9f, 100, 30), timeText, style); 

	}
}
