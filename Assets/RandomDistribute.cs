using UnityEngine;
using System.Collections;

public class RandomDistribute : MonoBehaviour {
	
	public GameObject parent;
	
	// Use this for initialization
	void Start () {
		
		Transform[] allChildren = parent.GetComponentsInChildren<Transform> ();
		
		foreach (Transform child in allChildren)
		{
			
			GameObject toDo = child.gameObject;
			RandomTransform(toDo);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void RandomTransform(GameObject theObject) {
		int x = Random.Range (1, 15);
		int y = Random.Range (1, 15);
		int z = Random.Range (1, 15);
		
		Vector3 trans = new Vector3 (x, y, z);
		
		theObject.transform.position = trans;
		
		
	}
}