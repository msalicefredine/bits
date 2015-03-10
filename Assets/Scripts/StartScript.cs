using UnityEngine;
using System.Collections;

public class StartScript : MonoBehaviour {
	private delegate void MenuDelegate();
	private MenuDelegate menuFunction;

	private float screenHeight;
	private float screenWidth;
	private float buttonHeight;
	private float buttonWidth;

	// Use this for initialization
	void Start () {
		screenHeight = Screen.height;
		screenWidth = Screen.width;

		// set up floats for button width and height based on screen
		buttonHeight = screenHeight * 0.3f;
		buttonWidth = screenWidth * 0.4f;

		menuFunction = anyKey;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGui () {

		menuFunction ();

	}

	void anyKey () {
		if (Input.anyKey) {
			menuFunction = mainMenu;
		}

		GUI.Label (new Rect (screenWidth * 0.45f, screenHeight * 0.45f, 0.1f, 0.1f), "Press Any Key to Continue");
	}

	void mainMenu() {
	}
}
