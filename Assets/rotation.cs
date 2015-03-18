using UnityEngine;
using System.Collections;

public class rotation : MonoBehaviour {
	public GameObject axis;
	private Vector3 rotationVector;
	public int rotationSpeed;

	// Use this for initialization
	void Start () {
		rotationVector = new Vector3 (Random.Range (0f,1f), Random.Range (0f,1f), Random.Range (0f,1f));
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround(axis.transform.position, rotationVector, rotationSpeed * Time.deltaTime);
	}
}
