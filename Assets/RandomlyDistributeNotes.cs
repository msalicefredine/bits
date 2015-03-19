using UnityEngine;
using System.Collections;

public class RandomlyDistributeNotes : MonoBehaviour {
	private int minDistance;
	
		// Use this for initialization
		void Start () {
		minDistance = 5;
			
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

	
		int xneg = Random.Range (-i, -minDistance);
		int xpos = Random.Range (minDistance, i);
		int[] selectionx = {xneg, xpos};
		int selectorx = (xneg % 2 == 0) ? 1 : 0;
		int x = selectionx [selectorx];

		int yneg = Random.Range (-i, -minDistance);
		int ypos = Random.Range (minDistance, i);
		int[] selectiony = {yneg, ypos};
		int selectory = (yneg % 2 == 0) ? 1 : 0;
		int y = selectiony [selectory];

		int zneg = Random.Range (-i, -minDistance);
		int zpos = Random.Range (minDistance, i);
		int[] selectionz = {zneg, zpos};
		int selectorz = (zneg % 2 == 0) ? 1 : 0;
		int z = selectionz [selectorz];

		//int x = Random.Range (-i, i);
		//int y = Random.Range (-i, i);
		//int z = Random.Range (-i, i);
			
			Vector3 trans = new Vector3 (x, y, z);
			
		eachTransform.position = trans;
			
			
		}

	int GetBoundaries(){
		if (GameState.currentLevel == 1)
			return 20;
		else if (GameState.currentLevel == 2)
			return 25;
		else if (GameState.currentLevel == 3 || GameState.currentLevel == 4)
			return 30;
		else
			return 35;
	}
	}