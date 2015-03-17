using UnityEngine;
using System.Collections;

public class RotationScript : MonoBehaviour {
	public int rotationFactor = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(1,1,0) * Time.deltaTime*rotationFactor);
	}
}
