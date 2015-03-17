using UnityEngine;
using System.Collections;

public class RandomlyDistributeNotes : MonoBehaviour {
	
		// Use this for initialization
		void Start () {
			
			foreach (Transform child in transform)
			{
				RandomTransform(child);
			}
			
		}
		
		// Update is called once per frame
		void Update () {
			
		}
		
		void RandomTransform(Transform eachTransform) {
			int x = Random.Range (-45, 45);
			int y = Random.Range (-45, 45);
			int z = Random.Range (-45, 45);
			
			Vector3 trans = new Vector3 (x, y, z);
			
		eachTransform.position = trans;
			
			
		}
	}