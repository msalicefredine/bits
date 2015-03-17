
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


	private AudioSource impact;
	private AudioSource thrusters;
	private AudioSource wrong;
	private AudioSource intro;
	private AudioSource outro;
	// Use this for initialization
	void Start () {
		sequence = new string[10];
		isAccelerating = false;
		AudioSource[] audios = GetComponents<AudioSource>();
		impact = audios [0];
		thrusters = audios [1];
		wrong = audios [2];
		intro = audios [3];
		outro = audios [4];
		shipBody.maxAngularVelocity = 0;
		currentSequenceIndex = 0;
		sequence [0] = "first";
		sequence [1] = "second";
		sequence [2] = "third";
		sequence [3] = "finished";
		intro.Play ();


	}

	void OnCollisionEnter(Collision collision) {
		if (!collision.gameObject.tag.Equals ("boundary"))
		impact.Play ();
		shipBody.velocity = Vector3.zero;
		}

	void OnTriggerEnter(Collider collision) {
		if (collision.gameObject.tag.Equals (sequence [currentSequenceIndex])) {
			collision.gameObject.GetComponent<AudioSource> ().Play ();
			currentSequenceIndex++;

		} else {
			wrong.Play ();
			currentSequenceIndex = 0;
		}
	
	}

	IEnumerator LevelIsFinished (){
		if(!outro.isPlaying)
		outro.Play ();
		yield return new WaitForSeconds (5);
		Application.LoadLevel ("level2");
	}

	// Update is called once per frame
	void Update () {
		if (sequence [currentSequenceIndex].Equals ("finished")) {
			StartCoroutine(LevelIsFinished ());
		}
		if(shipBody.velocity.sqrMagnitude > maxVelocity)
		{
			//smoothness of the slowdown is controlled by the 0.99f, 
			//0.5f is less smooth, 0.9999f is more smooth
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
			//transform.position = transform.position + camera.transform.forward * speed * Time.deltaTime;
		} else {
			isAccelerating = false;
			shipBody.drag = 1f;
			thrusters.Stop ();
		}
	}
	/*
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Good") {
			goodSound.Play ();
	}
		if(other.gameObject.tag == "Bad") {
			badSound.Play ();
		}*/

}
