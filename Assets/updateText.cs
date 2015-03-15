using UnityEngine;
using System.Collections;

public class updateText : MonoBehaviour {
	public Rigidbody body;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		GetComponent<TextMesh>().text = body.velocity.sqrMagnitude.ToString();
	
	}
}
