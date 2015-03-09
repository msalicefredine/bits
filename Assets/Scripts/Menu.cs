using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public bool showStart = false;
	private float screenHeight;
	private float screenWidth;
	private float buttonHeight;
	private float buttonWidth;
	private string level;

	// Use this for initialization
	void Start () {

		bool showStart = true;

		screenHeight = Screen.height;
		screenWidth = Screen.width;
		
		// set up floats for button width and height based on screen
		buttonHeight = screenHeight * 0.3f;
		buttonWidth = screenWidth * 0.4f;
	
	}

	void OnGui () {

		GUILayout.BeginArea (new Rect (0, 0, 200, 300));
		GUILayout.BeginVertical ();

		if (GUILayout.Button ("Start Game")) {
			showStart = false;
			Application.LoadLevel (level);
		}

		GUILayout.EndVertical ();
		GUILayout.EndArea ();  

		if (showStart) {
			showStart = true;
			
			GUILayout.BeginArea (new Rect (210, 0, 200, 300));
			GUILayout.BeginHorizontal ();
			//text column
			GUILayout.Label ("Game Options", GUILayout.Width (100));
			GUILayout.EndHorizontal ();
			//settings column
			GUILayout.BeginHorizontal ();
			GUILayout.Button ("Start Game");
			GUILayout.Button ("Quit");
			GUILayout.EndHorizontal ();
			GUILayout.EndArea ();
		} 

	}
}
