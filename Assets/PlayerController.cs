using UnityEngine;
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
