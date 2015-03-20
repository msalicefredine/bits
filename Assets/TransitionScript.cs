using UnityEngine;
using System.Collections;

public class TransitionScript : MonoBehaviour {

	public Rigidbody ship;
	public float speed;
	public TextMesh scoreText;
	public TextMesh next;
	public GameObject particleObject;
	public GameObject engineCharge;
	public Light light;
	public Canvas fadeToWhiteCanvas;

	// Use this for initialization
	void Start () {
		// start engines (2 seconds)
		next.text = "";
		scoreText.text = "";
		//engineCharge.SetActive (true);
		StartCoroutine ("warmUp");
		light.intensity = 0;
		fadeToWhiteCanvas.GetComponent<CanvasGroup> ().alpha = 1;

	}
	
	// Update is called once per frame
	void Update () {
		light.intensity += 0.05f;
		if(fadeToWhiteCanvas.GetComponent<CanvasGroup> ().alpha >= 0)
		fadeToWhiteCanvas.GetComponent<CanvasGroup> ().alpha -= 0.025f;
	
	}

	void runShip() {
		// Ship blasts off: apply force and start particle stuff
		ship.AddForce (Vector3.forward * speed, ForceMode.VelocityChange);
		//particleObject.SetActive(true);
	}

	void runButtons() {
		
		scoreText.text = "Your Time:\n" + GameState.levelTime;
		next.text = "Next Level";

		int i = 0;

		float r = scoreText.color.r;
		float g = scoreText.color.g;
		float b = scoreText.color.b;

		while (i < 255) {
			scoreText.GetComponent<Renderer>().material.color = new Color(r, g, b, i);
			next.GetComponent<Renderer>().material.color = new Color(r, g, b, i);
			                                
			i++;
		}
	}

	IEnumerator warmUp() {
		print ("this is called");
		GetComponent<AudioSource> ().Play ();
		yield return new WaitForSeconds(2.3f);
		runShip ();
		yield return new WaitForSeconds (1.0f);
		runButtons ();

	}
}
