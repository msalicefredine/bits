
﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Camera camera;
	public GUIText text;
	public string[] sequence;
	public Rigidbody shipBody;
	public GameObject particleObject;
	

	private bool isAccelerating;
	private float maxVelocity = 75;
	private int currentSequenceIndex;
	private string currentSequence;

	public GameObject notePlayerObject;
	public GameObject glowParentObject;
	public GameObject noteParentObject;
	public GameObject pauseText;
	public GameObject ambientSound;
	public GameObject otherSounds;

	private AudioSource notePlayer;
	private AudioSource impact;
	private AudioSource thrusters;

	private AudioSource intro;
	private AudioSource outro;

	private int fadeCounter;
	public Canvas fadeToWhiteCanvas;


	void Start () {
		sequence = new string[10];
		GameState.isPaused = false;
		isAccelerating = false;
		impact = GameObject.FindGameObjectWithTag ("collision").GetComponent<AudioSource> ();
		thrusters = GameObject.FindGameObjectWithTag ("thruster").GetComponent<AudioSource> ();
		intro = GameObject.FindGameObjectWithTag ("intro").GetComponent<AudioSource> ();
		outro = GameObject.FindGameObjectWithTag ("outro").GetComponent<AudioSource> ();
		shipBody.maxAngularVelocity = 0;
		SequenceBuilder ();
		intro.Play ();
		notePlayer = notePlayerObject.GetComponent<AudioSource> ();
		fadeToWhiteCanvas.GetComponent<CanvasGroup> ().alpha = 1;
		GameState.currentLevel++;
		GameState.isLevelOver = false;
	}

	void SequenceBuilder(){
		currentSequenceIndex = 0;
		sequence [0] = "first";
		sequence [1] = "second";
		sequence [2] = "third";
		if (GameState.currentLevel == 1)
			sequence [3] = "finished";
		else if (GameState.currentLevel == 3) {
			sequence [3] = "fourth";
			sequence [4] = "finished";
		}
		else if(GameState.currentLevel == 5){
			sequence [3] = "fourth";
		sequence [4] = "fifth";
		sequence [5] = "finished";
		}
		else if(GameState.currentLevel == 7){
			sequence [3] = "fourth";
		sequence [4] = "fifth";
		sequence [5] = "sixth";
		sequence [6] = "finished";
		}
		else if(GameState.currentLevel == 9){
			sequence [3] = "fourth";
		sequence [4] = "fifth";
		sequence [5] = "sixth";
		sequence [6] = "seventh";
		sequence [7] = "finished";
		}
	}

	void OnCollisionEnter(Collision collision) {
		if (!collision.gameObject.tag.Equals ("boundary") && !impact.isPlaying)
		impact.Play ();
		shipBody.velocity = Vector3.zero;
		}

	void WrongNote ()
	{
		currentSequenceIndex = 0;
		foreach (Transform item in glowParentObject.GetComponentInChildren<Transform> ()) {
			item.gameObject.SetActive (false);
		}
		foreach (Transform item in noteParentObject.GetComponentInChildren<Transform> ()) {
			item.gameObject.SetActive (true);
		}
	}

	void OnTriggerEnter(Collider collision) {
		notePlayer.clip = collision.gameObject.GetComponent<AudioSource> ().clip;
		notePlayer.Play ();
		if(collision.gameObject.tag.Equals("parent")){
			foreach (Transform unit in collision.transform){
				if (unit.gameObject.tag.Equals (sequence [currentSequenceIndex])){
					unit.parent.gameObject.SetActive(false);
					currentSequenceIndex++;
					foreach (Transform item in glowParentObject.GetComponentInChildren<Transform>()) {
						if (unit.gameObject.tag.Equals (item.tag))
							item.gameObject.SetActive (true);
					}
					return;
				}
			}
			WrongNote ();
		}
		else if (collision.gameObject.tag.Equals (sequence [currentSequenceIndex])) {
			currentSequenceIndex++;
			collision.gameObject.SetActive (false);
			foreach (Transform item in glowParentObject.GetComponentInChildren<Transform>()) {
				if (collision.gameObject.tag.Equals (item.tag))
					item.gameObject.SetActive (true);
			}
		
		} else {
			WrongNote ();
		}
	
	}
	

	// Update is called once per frame
	void Update () {
		if (GameState.isLevelOver) {
			if (fadeToWhiteCanvas.GetComponent<CanvasGroup> ().alpha != 1)
				fadeToWhiteCanvas.GetComponent<CanvasGroup> ().alpha += 0.008f;
			if (fadeToWhiteCanvas.GetComponent<CanvasGroup> ().alpha == 1) {
				//StartCoroutine (LevelIsFinished ());
				SequenceBuilder ();
				Application.LoadLevel (GameState.currentLevel);
			}
		} else if (GameState.isPaused == true) {

			if (Input.GetKeyDown(KeyCode.Escape)){
				Time.timeScale = 1;
				GameState.currentLevel = 1;
				GameState.isPaused = false;
				Application.LoadLevel (0);
			}

			if (Cardboard.SDK.CardboardTriggered) {
				GameState.isPaused = false;
				Time.timeScale = 1;
				ambientSound.SetActive(true);
				otherSounds.SetActive(true);
				pauseText.SetActive(false);
			}

		}

		else{
			if (sequence [currentSequenceIndex].Equals ("finished")) {
				GameState.isLevelOver = true;
			}
			if (shipBody.velocity.sqrMagnitude > maxVelocity) {
				shipBody.velocity *= 0.99f;
			}

			if (Input.GetKeyDown(KeyCode.Escape)){
				ambientSound.SetActive(false);
				otherSounds.SetActive(false);
				GameState.isPaused = true;
				pauseText.SetActive(true);
				Time.timeScale = 0;
			}

			if (Cardboard.SDK.CardboardTriggered) {
				isAccelerating = !isAccelerating;
				particleObject.SetActive (isAccelerating);
			}

			if (isAccelerating) {
				if (shipBody.velocity.sqrMagnitude < maxVelocity)
					shipBody.AddForce (camera.transform.forward * speed, ForceMode.Acceleration);
				shipBody.drag = 0;
				if (!thrusters.isPlaying)
					thrusters.Play ();
			} else {
				isAccelerating = false;
				shipBody.drag = 1f;
				thrusters.Stop ();
			}
		}
	}
}
