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
	private bool loading;


	// Use this for initialization
	void Start () {
		// start engines (2 seconds)
		next.text = "";
		scoreText.text = "";
		//engineCharge.SetActive (true);
		StartCoroutine ("warmUp");
		light.intensity = 0;
		fadeToWhiteCanvas.GetComponent<CanvasGroup> ().alpha = 1;
		loading = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		this.transform.rotation = Quaternion.identity;
		light.intensity += 0.05f;
		if (!loading) {
			if (fadeToWhiteCanvas.GetComponent<CanvasGroup> ().alpha >= 0)
				fadeToWhiteCanvas.GetComponent<CanvasGroup> ().alpha -= 0.025f;
		}

		if (loading) {
			if(fadeToWhiteCanvas.GetComponent<CanvasGroup> ().alpha <= 1)
				fadeToWhiteCanvas.GetComponent<CanvasGroup> ().alpha += 0.025f;
			if(fadeToWhiteCanvas.GetComponent<CanvasGroup> ().alpha >= 1) {
				GameState.currentLevel++;
				Application.LoadLevel (GameState.currentLevel);
			}
		}

	
	}

	void runShip() {
		ship.AddForce (Vector3.forward * speed, ForceMode.VelocityChange);
	}

	void runButtons() {
		
		scoreText.text = "Your Time:\n" + GameState.levelTime;
		next.text = "Loading...";

		int i = 0;
	}

	void loadNextLevel() {


		Application.LoadLevel (GameState.currentLevel);
	}

	IEnumerator warmUp() {
		print ("this is called");
		GetComponent<AudioSource> ().Play ();
		yield return new WaitForSeconds(2.3f);
		runShip ();
		yield return new WaitForSeconds (2.0f);
		runButtons ();
		yield return new WaitForSeconds (3.0f);
		loading = true;



	}
}
