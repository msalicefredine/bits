
﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Camera camera;
	public GUIText text;
	public int[] sequence;
	public Rigidbody shipBody;
	//public AudioSource goodSound;
	//public AudioSource badSound;
	// Use this for initialization
	void Start () {
		sequence = new int[10];
		//AudioSource[] audios = GetComponents<AudioSource>();
		//goodSound = audios [0];
		//badSound = audios [1];
	}

	void OnCollisionEnter(){
		rigidbody.angularVelocity = Vector3.zero;
		rigidbody.velocity = Vector3.zero;
	}

	
	// Update is called once per frame
	void Update () {

		transform.position = transform.position + camera.transform.forward * speed * Time.deltaTime;

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
