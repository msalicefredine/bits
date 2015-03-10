<<<<<<< HEAD
﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Camera camera;

	// Use this for initialization
	void Start () {
	
	
	}
	
	// Update is called once per frame
	void Update () {

		//transform.Translate(camera.transform.forward * speed * Time.deltaTime);
		transform.position = transform.position + camera.transform.forward * speed * Time.deltaTime;
	}
}
=======
﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Camera camera;
	public AudioSource goodSound;
	public AudioSource badSound;
	// Use this for initialization
	void Start () {

		AudioSource[] audios = GetComponents<AudioSource>();
		goodSound = audios [0];
		badSound = audios [1];
	
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate(camera.transform.forward * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Good") {
			goodSound.Play ();
	}
		if(other.gameObject.tag == "Bad") {
			badSound.Play ();
		}
}
}
>>>>>>> 503e0b73989c7b3eb1682a99d520acb9e0fc3100
