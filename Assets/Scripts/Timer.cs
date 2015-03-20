using UnityEngine;
using System.Collections;
using System;
using System.Reflection;

public class Timer : MonoBehaviour {

	private float levelTime;
	private float startTime;
	public GUIStyle style;
	// Use this for initialization
	void Start () {
		startTime = Time.deltaTime;
		print ("starting timer");
		//ALICE: Here is the variable you can work with: GameState.currentTime;
	}
	
	// Update is called once per frame
	void Update () {

		GameState.currentTime = Time.deltaTime - startTime;
		levelTime = Time.timeSinceLevelLoad;
		// int minutes = (int) GameState.currentTime / 60; 
		// int seconds = (int) GameState.currentTime % 60; 
		int minutes = (int) levelTime / 60; 
		int seconds = (int) levelTime % 60; 
		
		GameState.levelTime = String.Format ("{0:00}:{1:00}", minutes, seconds); 
		print (GameState.levelTime);
	}
	
}
