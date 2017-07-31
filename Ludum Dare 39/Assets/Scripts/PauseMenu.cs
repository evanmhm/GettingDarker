using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public bool paused;

	public GameObject pauseCanvas;
	public GameObject UICanvas;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			paused = !paused;
		}

		if (paused) {
			Time.timeScale = 0;
			Cursor.visible = true;
			pauseCanvas.SetActive(true);
			UICanvas.SetActive(false);
		} else {
			Time.timeScale = 1;
			Cursor.visible = false;
			pauseCanvas.SetActive(false);
			UICanvas.SetActive(true);
		}
	}
}
