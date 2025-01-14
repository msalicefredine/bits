﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class StaringAtTheSun : MonoBehaviour {
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

		private CardboardHead head;
		private Vector3 startingPosition;
		public Canvas fadeToWhiteCanvas;
		private float fadeCounter;
		private int i;
		
		void Start() {
			head = Camera.main.GetComponent<StereoController>().Head;
			startingPosition = transform.localPosition;
			CardboardGUI.IsGUIVisible = true;
			CardboardGUI.onGUICallback += this.OnGUI;
			fadeCounter = 0.0f;
		}
		
		void Update() {
		if (!GameState.isLevelOver) {
			RaycastHit hit;
			bool isLookedAt = GetComponent<Collider> ().Raycast (head.Gaze, out hit, Mathf.Infinity);
			GetComponent<Renderer> ().material.color = isLookedAt ? Color.white : Color.blue;
			if (isLookedAt) {
				if (fadeToWhiteCanvas.GetComponent<CanvasGroup> ().alpha <= 0.90f)
					fadeToWhiteCanvas.GetComponent<CanvasGroup> ().alpha += 0.008f;
				else if (fadeToWhiteCanvas.GetComponent<CanvasGroup> ().alpha <= 1)
					fadeToWhiteCanvas.GetComponent<CanvasGroup> ().alpha = 1;
				i++;
				
				if (i > 150) {
					GameState.currentLevel--;
					Application.LoadLevel (GameState.currentLevel);
				}
			} else {
				if (fadeToWhiteCanvas.GetComponent<CanvasGroup> ().alpha >= 0)
					fadeToWhiteCanvas.GetComponent<CanvasGroup> ().alpha -= 0.008f;
				if (i > 0)
					i--;
			}

		}
	}
		
		IEnumerator MyLoadLevel(float delay, string toLoad) {
			yield return new WaitForSeconds (delay);
			Application.LoadLevel (toLoad);
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
	}
