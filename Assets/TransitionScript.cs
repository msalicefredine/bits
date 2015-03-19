using UnityEngine;
using System.Collections;

public class TransitionScript : MonoBehaviour {

	public Rigidbody ship;
	public float speed;
	public TextMesh scoreText;
	public TextMesh next;
	public GameObject particleObject;
	public GameObject engineCharge;
	// Use this for initialization
	void Start () {
		// start engines (2 seconds)
		next.text = "";
		scoreText.text = "";
		engineCharge.SetActive (true);
		StartCoroutine ("warmUp");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void runShip() {
		// Ship blasts off: apply force and start particle stuff
		ship.AddForce (Vector3.forward * speed, ForceMode.Acceleration);
		particleObject.SetActive(true);
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
		yield return new WaitForSeconds(2.0f);
		runShip ();
		yield return new WaitForSeconds (1.0f);
		runButtons ();

	}
}
