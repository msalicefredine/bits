
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
	private float maxVelocity = 150;
	private int currentSequenceIndex;
	private string currentSequence;

	public GameObject notePlayerObject;
	public GameObject glowParentObject;
	public GameObject noteParentObject;

	private AudioSource notePlayer;
	private AudioSource impact;
	private AudioSource thrusters;
	private AudioSource wrong;
	private AudioSource intro;
	private AudioSource outro;
	// Use this for initialization
	void Start () {
		sequence = new string[10];
		isAccelerating = false;
		impact = GameObject.FindGameObjectWithTag ("collision").GetComponent<AudioSource> ();
		thrusters = GameObject.FindGameObjectWithTag ("thruster").GetComponent<AudioSource> ();
		wrong = GameObject.FindGameObjectWithTag ("wrong").GetComponent<AudioSource> ();
		intro = GameObject.FindGameObjectWithTag ("intro").GetComponent<AudioSource> ();
		outro = GameObject.FindGameObjectWithTag ("outro").GetComponent<AudioSource> ();
		shipBody.maxAngularVelocity = 0;
		SequenceBuilder ();
		intro.Play ();
		notePlayer = notePlayerObject.GetComponent<AudioSource> ();

	}

	void SequenceBuilder(){
		currentSequenceIndex = 0;
		sequence [0] = "first";
		sequence [1] = "second";
		sequence [2] = "third";
		if (GameState.currentLevel == 1)
			sequence [3] = "finished";
		else if (GameState.currentLevel == 2) {
			sequence [3] = "fourth";
			sequence [4] = "finished";
		}
		else if(GameState.currentLevel == 3){
			sequence [3] = "fourth";
		sequence [4] = "fifth";
		sequence [5] = "finished";
		}
		else if(GameState.currentLevel == 4){
			sequence [3] = "fourth";
		sequence [4] = "fifth";
		sequence [5] = "sixth";
		sequence [6] = "finished";
		}
		else if(GameState.currentLevel == 5){
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

	void OnTriggerEnter(Collider collision) {
		notePlayer.clip = collision.gameObject.GetComponent<AudioSource> ().clip;
		notePlayer.Play ();
		if (collision.gameObject.tag.Equals (sequence [currentSequenceIndex])) {
			//notePlayer.clip = collision.gameObject.GetComponent<AudioSource> ().clip;
			//notePlayer.Play ();
			currentSequenceIndex++;
			collision.gameObject.SetActive (false);

			foreach (Transform item in glowParentObject.GetComponentInChildren<Transform>()) {
				if (collision.gameObject.tag.Equals (item.tag))
					item.gameObject.SetActive (true);
			}
		
		} else {
			//wrong.Play();
			currentSequenceIndex = 0;
			foreach (Transform item in glowParentObject.GetComponentInChildren<Transform>()) {
		
					item.gameObject.SetActive (false);
			}
			foreach (Transform item in noteParentObject.GetComponentInChildren<Transform>()) {
				
				item.gameObject.SetActive (true);
			}
		}
	
	}

	IEnumerator LevelIsFinished (){
		if(!outro.isPlaying)
		outro.Play ();
		yield return new WaitForSeconds (5);
		GameState.currentLevel++;
		SequenceBuilder ();
		Application.LoadLevel (GameState.currentLevel);
	}

	// Update is called once per frame
	void Update () {
		if (sequence [currentSequenceIndex].Equals ("finished")) {
			StartCoroutine(LevelIsFinished ());
		}
		if(shipBody.velocity.sqrMagnitude > maxVelocity)
		{
			shipBody.velocity *= 0.99f;
		}


		if (Cardboard.SDK.CardboardTriggered) {
			isAccelerating = !isAccelerating;
			particleObject.SetActive(isAccelerating);
			}

		if (isAccelerating) {
			if(shipBody.velocity.sqrMagnitude < maxVelocity)
			shipBody.AddForce (camera.transform.forward * speed, ForceMode.Acceleration);
			shipBody.drag = 0;
			if(!thrusters.isPlaying)
			thrusters.Play();
		} else {
			isAccelerating = false;
			shipBody.drag = 1f;
			thrusters.Stop();
		}
	}
}
