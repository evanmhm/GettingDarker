using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {
	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.tag == "Player" || col.gameObject.tag == "PlayerWrapper") {
			SceneManager.LoadScene("WinScene", LoadSceneMode.Single);
		}
	}

}
