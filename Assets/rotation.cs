using UnityEngine;
using System.Collections;

public class rotation : MonoBehaviour {
	public GameObject axis;
	public Vector3 rotationVector;
	public int rotationSpeed;

	// Use this for initialization
	void Start () {
		//rotationVector = new Vector3 (1, 0, 1);
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround(axis.transform.position, rotationVector, rotationSpeed * Time.deltaTime);
	}
}
