using UnityEngine;
using System.Collections;

public class HowToPlayLabel : MonoBehaviour {

	public GUIStyle style;
	private CardboardHead head;
	private Vector3 startingPosition;

	// Use this for initialization
	void Start () {

		head = Camera.main.GetComponent<StereoController>().Head;
		startingPosition = transform.localPosition;
		CardboardGUI.IsGUIVisible = true;
		CardboardGUI.onGUICallback += this.OnGUI;

	
	}
	
	// Update is called once per frame
	void Update () {
		if (Cardboard.SDK.CardboardTriggered) {
			Application.LoadLevel ("mainMenu");
		}
	
	}

	void OnGUI () {

		string content = "How to Play\nTaverse the galaxies and play back the starsong on every level.\n" +
			"At each level, you will hear a melody upon starting. Tap the magnet to start your engines,\n" +
			"and fly your ship through the stars to collect the right notes before time runs out!\n\n" +
			"Tap the magnet to return to the main menu!";

		GUI.Label (new Rect (Screen.width * 0.1f, Screen.height * 0.1f, Screen.width * 0.8f, Screen.height * 0.8f), content, style);

	}
}
