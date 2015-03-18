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
		int i = GetBoundaries ();
		int x = Random.Range (-i, i);
		int y = Random.Range (-i, i);
		int z = Random.Range (-i, i);
			
			Vector3 trans = new Vector3 (x, y, z);
			
		eachTransform.position = trans;
			
			
		}

	int GetBoundaries(){
		if (GameState.currentLevel == 1)
			return 10;
		else if (GameState.currentLevel == 2)
			return 10;
		else if (GameState.currentLevel == 3 || GameState.currentLevel == 4)
			return 10;
		else
			return 10;
	}
	}