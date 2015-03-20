// Copyright 2014 Google Inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class Menu : MonoBehaviour {
	private CardboardHead head;
	private Vector3 startingPosition;
	public int level;
	private int i;
	private float r;
	private float g;

	
	void Start() {
		head = Camera.main.GetComponent<StereoController>().Head;
		startingPosition = transform.localPosition;
		CardboardGUI.IsGUIVisible = true;
		CardboardGUI.onGUICallback += this.OnGUI;
		r = 0.6f;
		g = 0.6f;
	}
	
	void Update() {
		RaycastHit hit;
		bool isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);
		if (isLookedAt) {
			print ("looking at text");
			i++;
			if ((i % 10) == 0) {
				GetComponent<Renderer>().material.color = new Color(r += 0.05f,g += 0.05f, 255);
			}

			if (i > 100) {
				GameState.currentLevel = level;
				Application.LoadLevel (level);
			}
		} 
		else {
			i = 0;
			r = 0.6f;
			g = 0.6f;
			GetComponent<Renderer>().material.color = new Color(0.5f, 0.5f, 1.0f);
		}
		if (Cardboard.SDK.CardboardTriggered && isLookedAt) {
			// Teleport randomly.
			/*Vector3 direction = Random.onUnitSphere;
			direction.y = Mathf.Clamp(direction.y, 0.5f, 1f);
			float distance = 2 * Random.value + 1.5f;
			transform.localPosition = direction * distance; */
			// load level.
		}
	}
	
	void OnGUI() {
		if (!CardboardGUI.OKToDraw(this)) {
			return;
		}
		if (GUI.Button(new Rect(50, 50, 200, 50), "Reset")) {
			transform.localPosition = startingPosition;
		}
		if (GUI.Button(new Rect(50, 110, 200, 50), "Recenter")) {
			Cardboard.SDK.Recenter();
		}

	}

	Color chooseColor(int index) {
		float r = (index / 100);
		float g = r;
		return new Color (r, g, 255);
	}
}
